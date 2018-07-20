using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace HardFuzz.Helpers
{
    internal static class MarshalingHelper
    {
        public static IEnumerable<T> AsUnmanagedArray<T>(this IntPtr head, uint length) where T : struct
        {
            var advance = Marshal.SizeOf<T>();
            for (var i = 0; i < length; i++) yield return Marshal.PtrToStructure<T>(IntPtr.Add(head, i * advance));
        }

        public static IEnumerable<T> AsUnmanagedArray<T>(this IntPtr head, Predicate<T> terminationPredicate)
            where T : struct
        {
            var advance = Marshal.SizeOf<T>();
            for (var i = 0; !terminationPredicate(Marshal.PtrToStructure<T>(IntPtr.Add(head, i))); i++)
                yield return Marshal.PtrToStructure<T>(IntPtr.Add(head, i * advance));
        }
    }
}