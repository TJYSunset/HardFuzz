using HardFuzz.HarfBuzz.Unicode;
using NUnit.Framework;

namespace HardFuzz.Test.BufferTests
{
    public partial class Tests
    {
        [Test]
        public void ClusterLevel()
        {
            Buffer.ClusterLevel = HarfBuzz.Buffer.ClusterLevel.Characters;
            Assert.That(Buffer.ClusterLevel, Is.EqualTo(HarfBuzz.Buffer.ClusterLevel.Characters));
        }

        [Test]
        public void ContentType()
        {
            Buffer.ContentType = HarfBuzz.Buffer.ContentType.Unicode;
            Assert.That(Buffer.ContentType, Is.EqualTo(HarfBuzz.Buffer.ContentType.Unicode));
            Assert.That(Buffer.ContentType, Is.Not.EqualTo(HarfBuzz.Buffer.ContentType.Invalid));
        }

        [Test]
        public void Direction()
        {
            Buffer.Direction = HarfBuzz.Direction.Ttb;
            Assert.That(Buffer.Direction, Is.EqualTo(HarfBuzz.Direction.Ttb));
            Assert.That(Buffer.Direction, Is.Not.EqualTo(HarfBuzz.Direction.Invalid));
        }

        [Test]
        public void Flags()
        {
            Buffer.Flags = HarfBuzz.Buffer.Flags.Bot | HarfBuzz.Buffer.Flags.PreserveDefaultIgnorables;
            Assert.That(Buffer.Flags,
                Is.EqualTo(HarfBuzz.Buffer.Flags.Bot | HarfBuzz.Buffer.Flags.PreserveDefaultIgnorables));
        }

        [Test]
        public void GlyphInfos()
        {
            var unused = Buffer.GlyphInfos;
            Buffer.AddUtf("ab");
            // ReSharper disable once RedundantAssignment
            unused = Buffer.GlyphInfos;
        }

        [Test]
        public void GlyphPositions()
        {
            var unused = Buffer.GlyphPositions;
            Buffer.AddUtf("ab");
            // ReSharper disable once RedundantAssignment
            unused = Buffer.GlyphPositions;
        }

        [Test]
        public void Language()
        {
            Buffer.Language = @"zh";
            Assert.That(Buffer.Language, Is.EqualTo(@"zh"));
        }

        [Test]
        public void Length()
        {
            Buffer.AddUtf("ab");
            Assert.That(Buffer.Length, Is.EqualTo(2));
        }

        [Test]
        public void ReplacementCodepoint()
        {
            Buffer.ReplacementCodepoint = 'R';
            Assert.That(Buffer.ReplacementCodepoint, Is.EqualTo('R'));
        }

        [Test]
        public void Script()
        {
            Buffer.Script = HarfBuzz.Script.Han;
            Assert.That(Buffer.Script, Is.EqualTo(HarfBuzz.Script.Han));
            Assert.That(Buffer.Script, Is.Not.EqualTo(HarfBuzz.Script.Invalid));
            Assert.That(Buffer.Script.ToString(), Is.EqualTo(@"Hani"));
        }

        [Test]
        public void UnicodeFunctions()
        {
            Buffer.UnicodeFunctions = Functions.Default;
            Assert.That(Buffer.UnicodeFunctions, Is.EqualTo(Functions.Default));
        }
    }
}