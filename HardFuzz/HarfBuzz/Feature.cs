using System.Runtime.InteropServices;
using System.Text;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz
{
    /// <summary>
    ///     hb_feature_t.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Feature
    {
        public Tag Tag;
        public uint value;
        public uint start;
        public uint end;

        /// <summary>
        ///     Parses a string into a <see cref="Feature" />.
        /// </summary>
        public Feature(string name)
        {
            var bytes = Encoding.ASCII.GetBytes(name);
            Api.hb_feature_from_string(bytes, bytes.Length, out this);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            const int allocatedSize = 128;
            var buffer = Marshal.AllocHGlobal(allocatedSize);
            try
            {
                Api.hb_feature_to_string(this, buffer, allocatedSize);
                return Marshal.PtrToStringAnsi(buffer, allocatedSize);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }
    }
}