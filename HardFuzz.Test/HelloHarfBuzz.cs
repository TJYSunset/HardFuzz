using System.Diagnostics.CodeAnalysis;
using System.Linq;
using HardFuzz.HarfBuzz.Buffer;
using HardFuzz.HarfBuzz.Shape;
using HardFuzz.SharpFont;
using NUnit.Framework;
using SharpFont;

namespace HardFuzz.Test
{
    [TestFixture]
    public class HelloHarfBuzz
    {
        [Test]
        [SuppressMessage("ReSharper", "UnusedVariable")]
        [SuppressMessage("ReSharper", "NotAccessedVariable")]
        public void Test()
        {
            using (var freetype = new Library())
            using (var fira = new Face(freetype, Utilities.GetResource(@"FiraSans-Regular.ttf")))
            using (var font = fira.ToHarfBuzzFont())
            using (var buffer = new Buffer())
            {
                buffer.AddUtf("Hello, HarfBuzz");
                buffer.GuessSegmentProperties();
                buffer.Shape(font);
                var info = buffer.GlyphInfos.ToArray();
                var pos = buffer.GlyphPositions.ToArray();
                var cursorX = 0d;
                var cursorY = 0d;
                for (var i = 0; i < buffer.Length; i++)
                {
                    var glyphId = info[i];
                    var xOffset = pos[i].XOffset / 64d;
                    var yOffset = pos[i].YOffset / 64d;
                    var xAdvance = pos[i].XAdvance / 64d;
                    var yAdvance = pos[i].YAdvance / 64d;
                    cursorX += xAdvance;
                    cursorY += yAdvance;
                }
            }
        }
    }
}