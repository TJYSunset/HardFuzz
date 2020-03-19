using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace HardFuzz.PlatformInvoke
{
    internal static partial class Api
    {
        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_ft_font_create(IntPtr ft_face, IntPtr destroy);
    }
}
