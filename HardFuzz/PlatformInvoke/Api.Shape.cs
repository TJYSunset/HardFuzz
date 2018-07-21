using System;
using System.Runtime.InteropServices;
using System.Text;
using HardFuzz.HarfBuzz;

// ReSharper disable InconsistentNaming

namespace HardFuzz.PlatformInvoke
{
    internal static partial class Api
    {
        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern bool hb_feature_from_string(byte[] str, int length, out Feature feature);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_feature_to_string(ref Feature feature,
            [MarshalAs(UnmanagedType.LPStr)] StringBuilder buf, uint size);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_shape(IntPtr font, IntPtr buffer,
            Feature[] features,
            uint num_features);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_shape_full(IntPtr font, IntPtr buffer,
            Feature[] features,
            uint num_features,
            byte[][] shaper_list);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        // ReSharper disable once ReturnTypeCanBeEnumerable.Global
        public static extern IntPtr hb_shape_list_shapers();
    }
}