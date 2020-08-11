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

        public Font(Face.Face face)
        {
            Handle = Api.hb_font_create(face.Handle);
        }

        /// <summary>
        ///     The pointer to the unmanaged hb_font_t object.
        /// </summary>
        public IntPtr Handle { get; }

        public (int x, int y) Scale
        {
            get
            {
                Api.hb_font_get_scale(Handle, out var x, out var y);
                return (x, y);
            }
            set => Api.hb_font_set_scale(Handle, value.x, value.y);
        }

        /// <remarks>
        ///     A zero value means "no hinting in that direction"
        /// </remarks>
        public (uint x, uint y) Ppem
        {
            get
            {
                Api.hb_font_get_ppem(Handle, out var x, out var y);
                return (x, y);
            }
            set => Api.hb_font_set_ppem(Handle, value.x, value.y);
        }

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
