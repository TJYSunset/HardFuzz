using System;
using System.Runtime.InteropServices;

namespace HardFuzz.PlatformInvoke
{
    internal static partial class Api
    {
        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_unicode_funcs_create(IntPtr parent);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_unicode_funcs_destroy(IntPtr ufuncs);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_unicode_funcs_get_default();
    }
}