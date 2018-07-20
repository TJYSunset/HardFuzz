using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using HardFuzz.Helpers;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz.Shape
{
    /// <summary>
    ///     Methods for hb-shaper.cc. Maybe.
    /// </summary>
    public static class Shaper
    {
        /// <summary>
        ///     Retrieves the list of shapers supported by HarfBuzz.
        /// </summary>
        public static IEnumerable<string> List =>
            Api.hb_shape_list_shapers()
                .AsUnmanagedArray<IntPtr>(x => x == IntPtr.Zero)
                .Select(x => Marshal.PtrToStringAnsi(x))
                .TakeWhile(x => !string.IsNullOrWhiteSpace(x));
    }
}