using System.Collections.Generic;
using System.Linq;
using System.Text;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz.Shape
{
    /// <summary>
    ///     Extension methods for shaping <see cref="HarfBuzz.Buffer" />s.
    /// </summary>
    public static class ShapeExtensions
    {
        /// <summary>
        ///     Shapes <paramref name="buffer" /> using font turning its Unicode characters content to positioned glyphs.
        ///     If <paramref name="features" /> is not empty, it will be used to control the features applied during
        ///     shaping.
        /// </summary>
        public static void Shape(this Buffer.Buffer buffer, Font.Font font, params Feature[] features)
        {
            Api.hb_shape(font.Handle, buffer.Handle, features, (uint) features.Length);
        }

        /// <summary>
        ///     Shapes <paramref name="buffer" /> using font turning its Unicode characters content to positioned glyphs.
        ///     If <paramref name="features" /> is not empty, it will be used to control the features applied during
        ///     shaping.
        ///     If <paramref cref="shapers" /> is not empty, the specified shapers will be used in the given order, otherwise
        ///     the default shapers list will be used.
        /// </summary>
        /// <param name="font"></param>
        /// <param name="buffer"></param>
        /// <param name="shapers"></param>
        /// <param name="features"></param>
        public static void Shape(this Buffer.Buffer buffer, Font.Font font, IEnumerable<string> shapers,
            params Feature[] features)
        {
            var bytes = shapers.Select(x => Encoding.ASCII.GetBytes(x)).ToArray();
            Api.hb_shape_full(font.Handle, buffer.Handle, features, (uint) features.Length, bytes);
        }
    }
}