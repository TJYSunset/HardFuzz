using System;

namespace HardFuzz.HarfBuzz.Buffer
{
    /// <summary>
    ///     hb_glyph_flags_t.
    ///     Flags.
    /// </summary>
    [Flags]
    public enum GlyphFlags
    {
        /// <summary>
        ///     Indicates that if input text is broken at the
        ///     beginning of the cluster this glyph is part of,
        ///     then both sides need to be re-shaped, as the
        ///     result might be different.  On the flip side,
        ///     it means that when this flag is not present,
        ///     then it's safe to break the glyph-run at the
        ///     beginning of this cluster, and the two sides
        ///     represent the exact same result one would get
        ///     if breaking input text at the beginning of
        ///     this cluster and shaping the two sides
        ///     separately.  This can be used to optimize
        ///     paragraph layout, by avoiding re-shaping
        ///     of each line after line-breaking, or limiting
        ///     the reshaping to a small piece around the
        ///     breaking point only.
        /// </summary>
        UnsafeToBreak = 0x00000001,

        /// <summary>
        ///     OR of all defined flags
        /// </summary>
        Defined = 0x00000001
    }
}