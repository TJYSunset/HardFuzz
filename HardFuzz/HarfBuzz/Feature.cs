using System;
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
        private uint _tag;
        public uint Value;
        public uint Start;
        public uint End;

        /// <summary>
        ///     Parses a string into a <see cref="Feature" />.
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public Feature(string name)
        {
            var bytes = Encoding.ASCII.GetBytes(name);
            if (!Api.hb_feature_from_string(bytes, bytes.Length, out this)) throw new ArgumentException(nameof(name));
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

        public Tag Tag
        {
            get => new Tag {Value = _tag};
            set => _tag = value.Value;
        }
    }
}