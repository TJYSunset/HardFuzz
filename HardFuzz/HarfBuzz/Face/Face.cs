using System;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz.Face
{
    /// <summary>
    ///     hb_face_t.
    /// </summary>
    public class Face : IDisposable
    {
        /// <inheritdoc />
        public Face(Blob.Blob blob, uint index = 0)
        {
            Handle = Api.hb_face_create(blob.Handle, index);
        }

        /// <summary>
        ///     The pointer to the unmanaged hb_face_t object.
        /// </summary>
        public IntPtr Handle { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            Api.hb_face_destroy(Handle);
        }
    }
}
