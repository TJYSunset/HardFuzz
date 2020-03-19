using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace HardFuzz.PlatformInvoke
{
    internal static partial class Api
    {
        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_blob_create(byte[] data, uint length, hb_memory_mode_t mode, IntPtr user_data,
                                                   IntPtr destroy);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_blob_destroy(IntPtr blob);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_blob_get_data(IntPtr blob, out uint length);

        internal enum hb_memory_mode_t
        {
            HB_MEMORY_MODE_DUPLICATE                  = 0,
            HB_MEMORY_MODE_READONLY                   = 1,
            HB_MEMORY_MODE_WRITABLE                   = 2,
            HB_MEMORY_MODE_READONLY_MAY_MAKE_WRITABLE = 3
        }
    }
}
