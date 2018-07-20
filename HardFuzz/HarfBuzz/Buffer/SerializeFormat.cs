namespace HardFuzz.HarfBuzz.Buffer
{
    /// <summary>
    ///     hb_buffer_serialize_format_t.
    ///     The buffer serialization and de-serialization format used in <see cref="Buffer.Serialize" /> and
    ///     <see cref="Buffer.Deserialize" />.
    /// </summary>
    public static class SerializeFormat
    {
        /// <summary>
        ///     a human-readable, plain text format.
        /// </summary>
        public static readonly Tag Text = new Tag(@"TEXT");

        /// <summary>
        ///     a machine-readable JSON format.
        /// </summary>
        public static readonly Tag Json = new Tag(@"JSON");

        /// <summary>
        ///     invalid format.
        /// </summary>
        public static readonly Tag Invalid = Tag.None;
    }
}