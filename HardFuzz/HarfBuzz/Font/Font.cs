using System;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz.Font
{
    /// <summary>
    ///     hb_font_t.
    /// </summary>
    public class Font : IDisposable
    {
        /// <inheritdoc />
        public Font(IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        ///     The pointer to the unmanaged hb_font_t object.
        /// </summary>
        public IntPtr Handle { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            Api.hb_font_destroy(Handle);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Font right && right.Handle == Handle;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }
    }
}