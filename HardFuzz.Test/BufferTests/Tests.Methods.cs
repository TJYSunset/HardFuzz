using HardFuzz.HarfBuzz.Buffer;
using HardFuzz.HarfBuzz.Shape;
using NUnit.Framework;
using SharpFont;

namespace HardFuzz.Test.BufferTests
{
    public partial class Tests
    {
        [Test]
        public void Add()
        {
            Buffer.ContentType = HarfBuzz.Buffer.ContentType.Unicode;
            Buffer.Add(1u, 0);
            Buffer.Add(new[] {1u});
            Buffer.Add(new[] {1u, 'a'});
            Buffer.Add(new[] {1u, 'a', 'b'}, 1, 1);
        }

        [Test]
        public void AddLatin1()
        {
            Buffer.AddLatin1(new byte[] {1});
            Buffer.AddLatin1(new byte[] {1, (byte) 'a'});
            Buffer.AddLatin1(new byte[] {1, (byte) 'a', (byte) 'b'}, 1, 1);
            Buffer.AddLatin1("\n");
            Buffer.AddLatin1("\na");
            Buffer.AddLatin1("\nab", 1, 1);
        }

        [Test]
        public void AddUtf()
        {
            Buffer.AddUtf(new[] {1u});
            Buffer.AddUtf(new[] {1u, 'a'});
            Buffer.AddUtf(new[] {1u, 'a', 'b'}, 1, 1);
            Buffer.AddUtf(new ushort[] {1});
            Buffer.AddUtf(new ushort[] {1, 'a'});
            Buffer.AddUtf(new ushort[] {1, 'a', 'b'}, 1, 1);
            Buffer.AddUtf(new byte[] {1});
            Buffer.AddUtf(new byte[] {1, (byte) 'a'});
            Buffer.AddUtf(new byte[] {1, (byte) 'a', (byte) 'b'}, 1, 1);
            Buffer.AddUtf("\n");
            Buffer.AddUtf("\na");
            Buffer.AddUtf("\nab", 1, 1);
        }

        [Test]
        public void Append()
        {
            using (var buffer = new Buffer())
            using (var buffer2 = new Buffer())
            {
                buffer2.AddUtf("ab");
                Buffer.Append(buffer);
                Buffer.Append(buffer2);
            }
        }

        [Test]
        public void ClearContents()
        {
            Buffer.ClearContents();
            Buffer.AddUtf("ab");
            Buffer.ClearContents();
        }

        [Test]
        public void GuessSegmentProperties()
        {
            Buffer.GuessSegmentProperties();
            Buffer.AddUtf("ab");
            Buffer.GuessSegmentProperties();
        }

        [Test]
        public void NormalizeGlyphs()
        {
            var unused = Buffer.GlyphPositions; // hb_buffer_normalize_glyphs() asserts buffer->have_position
            Buffer.NormalizeGlyphs();
        }

        [Test]
        public void Reset()
        {
            Buffer.Reset();
            Buffer.AddUtf("ab");
            Buffer.Reset();
        }

        [Test]
        public void Reverse()
        {
            Buffer.Reverse();
            Buffer.AddUtf("ab");
            Buffer.Reverse(0, 1);
        }

        [Test]
        public void ReverseClusters()
        {
            Buffer.ReverseClusters();
            Buffer.AddUtf("ab");
            Buffer.ReverseClusters();
        }

        [Test]
        public void SerializeAndDeserialize()
        {
            using (var freetype = new Library())
            using (var fira = new Face(freetype, Utilities.GetResource(@"FiraSans-Regular.ttf")))
            using (var font = fira.ToHarfBuzzFont())
            using (var deserialized = new Buffer())
            {
                Buffer.AddUtf("The quick brown The quick brown espan\u0303ol fox jumps over the lazy dog.");
                Buffer.Shape(font);
                var serialized = Buffer.Serialize(0, Buffer.Length, 2048, SerializeFormat.Text);
                TestContext.WriteLine("Serialized: " + serialized);

                TestContext.WriteLine();

                deserialized.Deserialize(serialized, SerializeFormat.Text);
                var reserialized = deserialized.Serialize(0, deserialized.Length, 2048, SerializeFormat.Text);
                TestContext.WriteLine("Reserialized: " + reserialized);

                Assert.That(reserialized, Is.EqualTo(serialized));
            }
        }
    }
}