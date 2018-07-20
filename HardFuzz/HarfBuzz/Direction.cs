namespace HardFuzz.HarfBuzz
{
    /// <summary>
    ///     hb_direction_t.
    /// </summary>
    public enum Direction
    {
        /// <summary>
        ///     Initial, unset direction.
        /// </summary>
        Invalid = 0,

        /// <summary>
        ///     Text is set horizontally from left to right.
        /// </summary>
        Ltr = 4,

        /// <summary>
        ///     Text is set horizontally from right to left.
        /// </summary>
        Rtl,

        /// <summary>
        ///     Text is set vertically from top to bottom.
        /// </summary>
        Ttb,

        /// <summary>
        ///     Text is set vertically from bottom to top.
        /// </summary>
        Btt
    }
}