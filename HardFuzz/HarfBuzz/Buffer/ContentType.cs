namespace HardFuzz.HarfBuzz.Buffer
{
    /// <summary>
    ///     hb_buffer_content_type_t.
    /// </summary>
    public enum ContentType
    {
        /// <summary>
        ///     Initial value for new buffer.
        /// </summary>
        Invalid = 0,

        /// <summary>
        ///     The buffer contains input characters (before shaping).
        /// </summary>
        Unicode,

        /// <summary>
        ///     The buffer contains output glyphs (after shaping).
        /// </summary>
        Glyphs
    }
}