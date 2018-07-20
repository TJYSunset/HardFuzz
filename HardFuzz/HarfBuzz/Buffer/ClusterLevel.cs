namespace HardFuzz.HarfBuzz.Buffer
{
    /// <summary>
    ///     hb_buffer_cluster_level_t.
    ///     Since 0.9.42
    /// </summary>
    public enum ClusterLevel
    {
        /// <summary>
        ///     See https://harfbuzz.github.io/clusters.html.
        /// </summary>
        MonotoneGraphemes = 0,

        /// <summary>
        ///     See https://harfbuzz.github.io/clusters.html.
        /// </summary>
        MonotoneCharacters = 1,

        /// <summary>
        ///     See https://harfbuzz.github.io/clusters.html.
        /// </summary>
        Characters = 2,

        /// <summary>
        ///     See https://harfbuzz.github.io/clusters.html.
        /// </summary>
        Default = MonotoneGraphemes
    }
}