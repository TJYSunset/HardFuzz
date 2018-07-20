using System.Linq;
using HardFuzz.HarfBuzz;
using HardFuzz.HarfBuzz.Buffer;
using HardFuzz.HarfBuzz.Font;
using HardFuzz.HarfBuzz.Shape;
using HardFuzz.SharpFont;
using NUnit.Framework;
using SharpFont;

namespace HardFuzz.Test.ShapeTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void SetUp()
        {
            Buffer = new Buffer
            {
                Direction = Direction.Ltr,
                Language = "en",
                Script = Script.Latin
            };
            FreeType = new Library();
            FiraSansRegular = new Face(FreeType, Utilities.GetResource(@"FiraSans-Regular.ttf"));
            Font = FiraSansRegular.ToHarfBuzzFont();
        }

        [TearDown]
        public void TearDown()
        {
            Font.Dispose();
            FiraSansRegular.Dispose();
            FreeType.Dispose();
            Buffer.Dispose();
        }

        public Buffer Buffer;
        public Library FreeType;
        public Face FiraSansRegular;
        public Font Font;

        [Test]
        public void Feature()
        {
            var feature = new Feature("valt");
            Assert.That(feature.Tag.ToString(), Is.EqualTo("valt"));
            Assert.That(new Feature(feature.ToString()).Tag.ToString(), Is.EqualTo("valt"));
        }

        [Test]
        public void ListShapers()
        {
            TestContext.WriteLine(string.Join(", ", Shaper.List));
        }

        [Test]
        public void Shape()
        {
            Buffer.AddUtf("The quick brown espan\u0303ol fox jumps over the lazy dog/");
            Buffer.GuessSegmentProperties();
            var glyphInfoBeforeShaping = Buffer.GlyphInfos.ToArray();
            var glyphPositionsBeforeShaping = Buffer.GlyphPositions.ToArray();
            TestContext.WriteLine("===== Before Shaping =====");
            TestContext.WriteLine("## GlyphInfos:\n" + string.Join(",\n", glyphInfoBeforeShaping
                                      .Select(x =>
                                          $"[{x.Codepoint.AsUnicodeCodepoint()}|{x.GetGlyphFlags()}|{x.Cluster}]")));
            TestContext.WriteLine("## GlyphPositions:\n" + string.Join(",\n", glyphPositionsBeforeShaping
                                      .Select(x => $"[{x.XAdvance}|{x.YAdvance}|{x.XOffset}|{x.YOffset}]")));

            TestContext.WriteLine();

            Buffer.Shape(Font);
            var glyphInfoAfterShaping = Buffer.GlyphInfos.ToArray();
            var glyphPositionsAfterShaping = Buffer.GlyphPositions.ToArray();
            TestContext.WriteLine("===== After Shaping =====");
            TestContext.WriteLine("## GlyphInfos:\n" + string.Join(",\n", glyphInfoAfterShaping
                                      .Select(x => $"[{x.Codepoint}|{x.GetGlyphFlags()}|{x.Cluster}]")));
            TestContext.WriteLine("## GlyphPositions:\n" + string.Join(",\n", glyphPositionsAfterShaping
                                      .Select(x => $"[{x.XAdvance}|{x.YAdvance}|{x.XOffset}|{x.YOffset}]")));

            Assert.That(glyphInfoBeforeShaping, Is.Not.EquivalentTo(glyphInfoAfterShaping));
            Assert.That(glyphPositionsBeforeShaping, Is.Not.EquivalentTo(glyphPositionsAfterShaping));
        }
    }
}