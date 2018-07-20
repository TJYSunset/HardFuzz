using System;
using System.Reflection;
using HardFuzz.HarfBuzz.Font;
using HardFuzz.SharpFont.PlatformInvoke;
using SharpFont;

namespace HardFuzz.SharpFont
{
    /// <summary>
    ///     Extension methods for <see cref="SharpFont" />.
    /// </summary>
    public static class SharpFontExtensions
    {
        /// <summary>
        ///     Constructs a new <see cref="Font" /> with <paramref name="face" />.
        /// </summary>
        public static Font ToHarfBuzzFont(this Face face)
        {
            var faceHandleProperty = typeof(Face).GetProperty(@"Reference",
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (faceHandleProperty == null)
                throw new InvalidOperationException(
                    @"Failed to get SharpFont.Face.Reference; might due to breaking internal changes in SharpFont.");
            return new Font(Api.hb_ft_font_create((IntPtr) faceHandleProperty.GetValue(face), IntPtr.Zero));
        }
    }
}