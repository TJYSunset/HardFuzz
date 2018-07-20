using System;
using NUnit.Framework;
using Buffer = HardFuzz.HarfBuzz.Buffer.Buffer;

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
            throw new NotImplementedException();
        }
    }
}