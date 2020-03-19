using System;
using System.Runtime.InteropServices;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz.Blob
{
    public class Blob : IDisposable
    {
        public IntPtr Handle { get; }
        public int    Length { get; }

        public Blob(byte[] data)
        {
            Handle = Api.hb_blob_create(data, (uint) data.Length, Api.hb_memory_mode_t.HB_MEMORY_MODE_READONLY,
                IntPtr.Zero, IntPtr.Zero);
            Length = data.Length;
        }

        public byte[] GetData()
        {
            var ptr  = Api.hb_blob_get_data(Handle, out var length);
            var data = new byte[length];
            Marshal.Copy(ptr, data, 0, (int) length);
            return data;
        }

        public void Dispose()
        {
            Api.hb_blob_destroy(Handle);
        }
    }
}
