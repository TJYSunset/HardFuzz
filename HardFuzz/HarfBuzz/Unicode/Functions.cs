using System;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz.Unicode
{
    /// <summary>
    ///     hb_buffer_unicode_funcs_t (as a pointer).
    /// </summary>
    public class Functions : IDisposable
    {
        /// <summary>
        ///     hb_unicode_funcs_get_default().
        /// </summary>
        public static readonly Functions Default = new Functions(Api.hb_unicode_funcs_get_default());

        /// <inheritdoc />
        public Functions(IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        ///     The pointer to the unmanaged hb_buffer_unicode_funcs_t object.
        /// </summary>
        public IntPtr Handle { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            Api.hb_unicode_funcs_destroy(Handle);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Functions right && right.Handle == Handle;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }
    }
}