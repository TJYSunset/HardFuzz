using System.Runtime.InteropServices;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz.Buffer
{
    /// <summary>
    ///     hb_glyph_info_t.
    ///     The structure that holds information about the glyphs and their relation to input text.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = 20)] // how can three 32-bit unsigned integers be 20 bytes?????
    public struct GlyphInfo
    {
        /// <summary>
        ///     either a Unicode code point (before shaping) or a glyph index (after shaping).
        /// </summary>
        public uint Codepoint;

        /// <summary>
        ///     Holds hb_glyph_flags_t after hb_shape(), plus other things.
        /// </summary>
        public uint Mask;

        /// <summary>
        ///     the index of the character in the original text that corresponds to this <see cref="GlyphInfo" />, or
        ///     whatever the client passes to <see cref="Buffer.Add(uint, uint)" />. More than one
        ///     <see cref="GlyphInfo" /> can have the same cluster value, if they resulted from the same character
        ///     (e.g. one to many glyph substitution), and when more than one character gets merged in the same glyph
        ///     (e.g. many to one glyph substitution) the <see cref="GlyphInfo" /> will have the smallest cluster value
        ///     of them. By default some characters are merged into the same cluster (e.g. combining marks have the same
        ///     cluster as their bases) even if they are separate glyphs, <see cref="Buffer.ClusterLevel" /> allow
        ///     selecting more fine-grained cluster handling.
        /// </summary>
        public uint Cluster;
    }

    /// <summary>
    ///     Extension methods for <see cref="GlyphInfo" />.
    /// </summary>
    public static class GlyphInfoExtensions
    {
        /// <summary>
        ///     Returns glyph flags encoded within <paramref name="info" />.
        /// </summary>
        public static GlyphFlags GetGlyphFlags(this GlyphInfo info)
        {
            return Api.hb_glyph_info_get_glyph_flags(ref info);
        }
    }
}