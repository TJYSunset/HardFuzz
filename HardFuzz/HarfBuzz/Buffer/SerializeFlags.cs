using System;

namespace HardFuzz.HarfBuzz.Buffer
{
    /// <summary>
    ///     hb_buffer_serialize_flags_t.
    ///     Flags that control what glyph information are serialized in <see cref="Buffer.Serialize" />.
    /// </summary>
    [Flags]
    public enum SerializeFlags : uint
    {
        /// <summary>
        ///     serialize glyph names, clusters and positions.
        /// </summary>
        Default = 0x00000000u,

        /// <summary>
        ///     do not serialize glyph cluster.
        /// </summary>
        NoClusters = 0x00000001u,

        /// <summary>
        ///     do not serialize glyph position information.
        /// </summary>
        NoPositions = 0x00000002u,

        /// <summary>
        ///     do no serialize glyph name.
        /// </summary>
        NoGlyphNames = 0x00000004u,

        /// <summary>
        ///     serialize glyph extents.
        /// </summary>
        GlyphExtents = 0x00000008u,

        /// <summary>
        ///     serialize glyph flags. Since: 1.5.0
        /// </summary>
        GlyphFlags = 0x00000010u,

        /// <summary>
        ///     do not serialize glyph advances, glyph offsets will reflect absolute glyph positions. Since: 1.8.0
        /// </summary>
        NoAdvances = 0x00000020u
    }
}