using System;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz.Font
{
    /// <summary>
    ///     hb_font_t.
    /// </summary>
    public class Font : IDisposable
    {
        /// <inheritdoc />
        public Font(IntPtr handle)
        {
            Handle = handle;
        }

        public Font(Blob.Blob blob, uint index = 0)
        {
            var face = Api.hb_face_create(blob.Handle, index);
            Handle = Api.hb_font_create(face);
            Api.hb_face_destroy(face);
        }

        /// <summary>
        ///     The pointer to the unmanaged hb_font_t object.
        /// </summary>
        public IntPtr Handle { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            Api.hb_font_destroy(Handle);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Font right && right.Handle == Handle;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        /// <summary>
        ///     Create a font from a FreeType face object.
        /// </summary>
        /// <param name="face">Native handle to a FreeType face.</param>
        /// <returns>A new HarfBuzz Font.</returns>
        public static Font FromFreeType(IntPtr face)
        {
            return new Font(Api.hb_ft_font_create(face, IntPtr.Zero));
        }
    }
}
