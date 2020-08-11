using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace HardFuzz.PlatformInvoke
{
    internal static partial class Api
    {
        // todo

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_font_create(IntPtr face);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_font_destroy(IntPtr font);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_font_get_scale(IntPtr font, out int x_scale, out int y_scale);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_font_set_scale(IntPtr font, int x_scale, int y_scale);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_font_get_ppem(IntPtr font, out uint x_ppem, out uint y_ppem);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_font_set_ppem(IntPtr font, uint x_ppem, uint y_ppem);
    }
}
