using System;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace HardFuzz.PlatformInvoke
{
    internal static partial class Api
    {
        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_face_create(IntPtr blob, uint index);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_face_destroy(IntPtr blob);
    }
}
