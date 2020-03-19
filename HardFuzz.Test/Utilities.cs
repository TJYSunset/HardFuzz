using System;
using System.IO;
using HardFuzz.HarfBuzz.Font;
using SharpFont;
using Encoding = System.Text.Encoding;

namespace HardFuzz.Test
{
    public static class Utilities
    {
        public static string AsUnicodeCodepoint(this uint codepoint)
        {
            return Encoding.UTF32.GetString(BitConverter.GetBytes(codepoint));
        }

        public static string GetResource(string filename)
        {
            return Path.Combine(
                Path.GetDirectoryName(typeof(Utilities).Assembly.Location) ??
                throw new InvalidOperationException(), filename);
        }

        public static Font ToHarfBuzzFont(this Face face)
        {
            return Font.FromFreeType(face.Reference);
        }
    }
}
