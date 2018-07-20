using System.Runtime.InteropServices;

namespace HardFuzz.HarfBuzz.Buffer
{
    /// <summary>
    ///     hb_glyph_position_t.
    ///     The structure that holds the positions of the glyph in both horizontal and vertical directions. All
    ///     positions in <see cref="GlyphPosition" /> are relative to the current point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 20)] // the fuck???
    public struct GlyphPosition
    {
        /// <summary>
        ///     how much the line advances after drawing this glyph when setting text in horizontal direction.
        /// </summary>
        public int XAdvance;

        /// <summary>
        ///     how much the line advances after drawing this glyph when setting text in vertical direction.
        /// </summary>
        public int YAdvance;

        /// <summary>
        ///     how much the glyph moves on the X-axis before drawing it, this should not affect how much the line
        ///     advances.
        /// </summary>
        public int XOffset;

        /// <summary>
        ///     how much the glyph moves on the Y-axis before drawing it, this should not affect how much the line
        ///     advances.
        /// </summary>
        public int YOffset;
    }
}