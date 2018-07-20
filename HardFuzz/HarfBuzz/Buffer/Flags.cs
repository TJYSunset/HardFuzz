using System;

namespace HardFuzz.HarfBuzz.Buffer
{
    /// <summary>
    ///     hb_buffer_flags_t.
    /// </summary>
    [Flags]
    public enum Flags : uint
    {
        /// <summary>
        ///     the default buffer flag.
        /// </summary>
        Default = 0x00000000u,

        /// <summary>
        ///     flag indicating that special handling of the beginning
        ///     of text paragraph can be applied to this buffer. Should usually
        ///     be set, unless you are passing to the buffer only part
        ///     of the text without the full context.
        /// </summary>
        Bot = 0x00000001u,

        /// <summary>
        ///     flag indicating that special handling of the end of text
        ///     paragraph can be applied to this buffer, similar to
        ///     <see cref="Bot" />.
        /// </summary>
        Eot = 0x00000002u,

        /// <summary>
        ///     flag indication that character with Default_Ignorable
        ///     Unicode property should use the corresponding glyph
        ///     from the font, instead of hiding them (done by
        ///     replacing them with the space glyph and zeroing the
        ///     advance width.)  This flag takes precedence over
        ///     <see cref="RemoveDefaultIgnorables" />.
        /// </summary>
        PreserveDefaultIgnorables = 0x00000004u,

        /// <summary>
        ///     flag indication that character with Default_Ignorable
        ///     Unicode property should be removed from glyph string
        ///     instead of hiding them (done by replacing them with the
        ///     space glyph and zeroing the advance width.)
        ///     <see cref="PreserveDefaultIgnorables" /> takes
        ///     precedence over this flag. Since: 1.8.0
        /// </summary>
        RemoveDefaultIgnorables = 0x00000008u
    }
}