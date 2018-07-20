using System;
using System.Runtime.InteropServices;

namespace HardFuzz.PlatformInvoke
{
    internal static partial class Api
    {
        // todo

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_font_create();

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_font_destroy(IntPtr font);
    }
}