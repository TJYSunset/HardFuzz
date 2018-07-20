using System.Runtime.InteropServices;

namespace HardFuzz.PlatformInvoke
{
    internal static partial class Api
    {
        private const string HarfBuzzDll = @"libharfbuzz-0.dll";
        private const CallingConvention Cdecl = CallingConvention.Cdecl;
    }
}