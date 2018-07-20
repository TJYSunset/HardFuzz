using System;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz
{
    /// <summary>
    ///     hb_language_t.
    /// </summary>
    public class Language
    {
        /// <summary>
        ///     hb_language_get_default().
        /// </summary>
        public static readonly Language Default = new Language(Api.hb_language_get_default());

        /// <inheritdoc />
        public Language(IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        ///     The pointer to the unmanaged hb_language_impl_t object.
        /// </summary>
        public IntPtr Handle { get; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Language right && right.Handle == Handle;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }
    }
}