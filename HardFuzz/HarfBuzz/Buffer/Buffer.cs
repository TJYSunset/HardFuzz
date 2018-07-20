using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using HardFuzz.HarfBuzz.Unicode;
using HardFuzz.Helpers;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz.Buffer
{
    /// <summary>
    ///     hb_buffer_t.
    ///     The main structure holding the input text and its properties before shaping, and output glyphs and their
    ///     information after shaping.
    /// </summary>
    public class Buffer : IDisposable
    {
        #region Constants

        /// <summary>
        ///     The default code point for replacing invalid characters in a given encoding. Set to U+FFFD REPLACEMENT
        ///     CHARACTER.
        /// </summary>
        public const uint DefaultReplacementCodepoint = 0xFFFDu;

        #endregion

        /// <inheritdoc />
        public Buffer()
        {
            Handle = Api.hb_buffer_reference(Api.hb_buffer_create());
        }

        /// <summary>
        ///     The pointer to the unmanaged hb_buffer_t object.
        /// </summary>
        public IntPtr Handle { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            Api.hb_buffer_destroy(Handle);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Buffer right && right.Handle == Handle;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Handle.GetHashCode();
        }

        #region Methods

        /// <summary>
        ///     Resets the buffer to its initial status, as if it was just newly created with the constructor.
        /// </summary>
        public void Reset()
        {
            Api.hb_buffer_reset(Handle);
        }

        /// <summary>
        ///     Similar to <see cref="Reset" />, but does not clear the Unicode functions and the replacement code point.
        /// </summary>
        public void ClearContents()
        {
            Api.hb_buffer_clear_contents(Handle);
        }

        /// <summary>
        ///     Appends a character with the Unicode value of <paramref name="codepoint" /> to buffer, and gives it the
        ///     initial cluster value of <paramref name="cluster" />. Clusters can be any thing the client wants, they
        ///     are usually used to refer to the index of the character in the input text stream and are output in
        ///     <see cref="GlyphInfo.Cluster" /> field.
        /// </summary>
        /// <remarks>
        ///     This function does not check the validity of <paramref name="codepoint" />, it is up to the caller to
        ///     ensure it is a valid Unicode code point.
        /// </remarks>
        public void Add(uint codepoint, uint cluster)
        {
            Api.hb_buffer_add(Handle, codepoint, cluster);
        }

        /// <summary>
        ///     Appends characters from <paramref name="text" /> to buffer. The <paramref name="itemOffset" /> is the
        ///     position of the first character from <paramref name="text" /> that will be appended, and
        ///     <paramref name="itemLength" /> is the number of character. When shaping part of a larger text (e.g. a
        ///     run of text from a paragraph), instead of passing just the substring corresponding to the run, it is
        ///     preferable to pass the whole paragraph and specify the run start and length as
        ///     <paramref name="itemOffset" /> and <paramref name="itemLength" />, respectively, to give HarfBuzz the full
        ///     context to be able, for example, to do cross-run Arabic shaping or properly handle combining marks at
        ///     stat of run.
        /// </summary>
        /// <remarks>
        ///     This function does not check the validity of <paramref name="text" />, it is up to the caller to ensure
        ///     it contains a valid Unicode code points.
        /// </remarks>
        public void Add(uint[] text, uint itemOffset = 0, int itemLength = -1)
        {
            Api.hb_buffer_add_codepoints(Handle, text, text.Length, itemOffset,
                itemLength > -1 ? itemLength : text.Length);
        }

        /// <seealso cref="Add(uint,uint)" />
        /// <summary>
        ///     Replaces invalid UTF-32 characters with the buffer replacement code point, see
        ///     <see cref="ReplacementCodepoint" />.
        /// </summary>
        public void AddUtf(uint[] text, uint itemOffset = 0, int itemLength = -1)
        {
            Api.hb_buffer_add_utf32(Handle, text, text.Length, itemOffset, itemLength > -1 ? itemLength : text.Length);
        }

        /// <seealso cref="Add(uint,uint)" />
        /// <summary>
        ///     Replaces invalid UTF-16 characters with the buffer replacement code point, see
        ///     <see cref="ReplacementCodepoint" />.
        /// </summary>
        public void AddUtf(ushort[] text, uint itemOffset = 0, int itemLength = -1)
        {
            Api.hb_buffer_add_utf16(Handle, text, text.Length, itemOffset, itemLength > -1 ? itemLength : text.Length);
        }

        /// <seealso cref="Add(uint,uint)" />
        /// <summary>
        ///     Replaces invalid UTF-8 characters with the buffer replacement code point, see
        ///     <see cref="ReplacementCodepoint" />.
        /// </summary>
        public void AddUtf(byte[] text, uint itemOffset = 0, int itemLength = -1)
        {
            Api.hb_buffer_add_utf8(Handle, text, text.Length, itemOffset, itemLength > -1 ? itemLength : text.Length);
        }

        /// <seealso cref="AddUtf(byte[],uint,int)" />
        public void AddUtf(string text, uint itemOffset = 0, int itemLength = -1)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            AddUtf(bytes, itemOffset, itemLength > -1 ? itemLength : bytes.Length);
        }

        /// <summary>
        ///     Similar to <see cref="Add(uint,uint)" />, but allows only access to first 256 Unicode code points that
        ///     can fit in 8-bit strings.
        /// </summary>
        public void AddLatin1(byte[] text, uint itemOffset = 0, int itemLength = -1)
        {
            Api.hb_buffer_add_latin1(Handle, text, text.Length, itemOffset, itemLength > -1 ? itemLength : text.Length);
        }

        /// <seealso cref="AddLatin1(byte[],uint,int)" />
        public void AddLatin1(string text, uint itemOffset = 0, int itemLength = -1)
        {
            var bytes = Encoding.GetEncoding(@"ISO-8859-1").GetBytes(text);
            AddUtf(bytes, itemOffset, itemLength > -1 ? itemLength : bytes.Length);
        }

        /// <summary>
        ///     Append (part of) contents of <paramref name="buffer" /> to this buffer.
        /// </summary>
        /// <param name="buffer">an <see cref="Buffer" />.</param>
        /// <param name="start">start index into <paramref name="buffer" /> to copy. Use 0 to copy from start of buffer.</param>
        /// <param name="end">
        ///     end index into <paramref name="buffer" /> to copy. Use <see cref="uint.MaxValue" /> to copy to end of
        ///     buffer.
        /// </param>
        public void Append(Buffer buffer, uint start = 0, uint end = uint.MaxValue)
        {
            Api.hb_buffer_append(Handle, buffer.Handle, start, end);
        }

        /// <summary>
        ///     Sets unset buffer segment properties based on buffer Unicode contents. If buffer is not empty, it
        ///     must have content type <see cref="HarfBuzz.Buffer.ContentType.Unicode" />.
        ///     <br />
        ///     If buffer script is not set (ie. is <see cref="HarfBuzz.Script.Invalid" />), it will be set to the
        ///     Unicode script of the first character in the buffer that has a script other than
        ///     <see cref="HarfBuzz.Script.Common" />, <see cref="HarfBuzz.Script.Inherited" />, and
        ///     <see cref="HarfBuzz.Script.Unknown" />.
        ///     <br />
        ///     Next, if buffer direction is not set (ie. is <see cref="HarfBuzz.Direction.Invalid" />), it will be set
        ///     to the natural horizontal direction of the buffer script as returned by
        ///     hb_script_get_horizontal_direction(). If hb_script_get_horizontal_direction() returns
        ///     <see cref="HarfBuzz.Direction.Invalid" />, then <see cref="HarfBuzz.Direction.Ltr" /> is used.
        ///     <br />
        ///     Finally, if buffer language is not set (ie. is HB_LANGUAGE_INVALID), it will be set to the process's
        ///     default language as returned by <see cref="HarfBuzz.Language.Default" />. This may change in the future
        ///     by taking buffer script into consideration when choosing a language.
        /// </summary>
        public void GuessSegmentProperties()
        {
            Api.hb_buffer_guess_segment_properties(Handle);
        }

        /// <summary>
        ///     Reorders a glyph buffer to have canonical in-cluster glyph order / position. The resulting clusters
        ///     should behave identical to pre-reordering clusters.
        /// </summary>
        public void NormalizeGlyphs()
        {
            Api.hb_buffer_normalize_glyphs(Handle);
        }

        /// <summary>
        ///     Reverses buffer contents.
        /// </summary>
        public void Reverse()
        {
            Api.hb_buffer_reverse(Handle);
        }

        /// <summary>
        ///     Reverses buffer contents between <paramref name="start" /> to <paramref name="end" />.
        /// </summary>
        public void Reverse(uint start, uint end)
        {
            Api.hb_buffer_reverse_range(Handle, start, end);
        }

        /// <summary>
        ///     Reverses buffer clusters. That is, the buffer contents are reversed, then each cluster (consecutive
        ///     items having the same cluster number) are reversed again.
        /// </summary>
        public void ReverseClusters()
        {
            Api.hb_buffer_reverse_clusters(Handle);
        }

        /// <summary>
        ///     Serializes buffer into a textual representation of its glyph content, useful for showing the contents
        ///     of the buffer, for example during debugging. There are currently two supported serialization formats.
        /// </summary>
        /// <param name="start">the first item in buffer to serialize.</param>
        /// <param name="end">
        ///     thought the official manual says it's "the last item in buffer to serialize", it looks more like
        ///     "actual running length of items to serialize" to me.
        /// </param>
        /// <param name="bufferSize">the size of unmanaged buffer for receiving the serialized string.</param>
        /// <param name="format">the <see cref="SerializeFormat" /> to use for formatting the output.</param>
        /// <param name="flags">the <see cref="SerializeFlags" /> that control what glyph properties to serialize.</param>
        /// <param name="font">
        ///     the <see cref="Font" /> used to shape this buffer, needed to read glyph names and extents. If NULL,
        ///     and empty font will be used.
        /// </param>
        public string Serialize(uint start, uint end, uint bufferSize, Tag format,
            SerializeFlags flags = SerializeFlags.Default, Font.Font font = null)
        {
            var buffer = Marshal.AllocHGlobal((int) bufferSize);
            try
            {
                Api.hb_buffer_serialize_glyphs(Handle, start, end, buffer, bufferSize, out var consumed,
                    font?.Handle ?? IntPtr.Zero, format, flags);
                return Marshal.PtrToStringAnsi(buffer, (int) consumed);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        /// <seealso cref="Serialize" />
        public void Deserialize(string data, Tag format, Font.Font font = null)
        {
            // todo throw an exception if the return value will indicate unsuccessful deserialization
            var bytes = Encoding.ASCII.GetBytes(data);
            Api.hb_buffer_deserialize_glyphs(Handle, bytes, bytes.Length, out _, font?.Handle ?? IntPtr.Zero, format);
        }

        #endregion

        #region Properties

        /// <summary>
        ///     The type of buffer contents, buffers are either empty, contain characters (before shaping) or glyphs
        ///     (the result of shaping).
        /// </summary>
        public ContentType ContentType
        {
            get => Api.hb_buffer_get_content_type(Handle);
            set => Api.hb_buffer_set_content_type(Handle, value);
        }

        /// <summary>
        ///     The text flow direction of the buffer. No shaping can happen without setting buffer direction, and it
        ///     controls the visual direction for the output glyphs; for RTL direction the glyphs will be reversed.
        ///     Many layout features depend on the proper setting of the direction, for example, reversing RTL text
        ///     before shaping, then shaping with LTR direction is not the same as keeping the text in logical order
        ///     and shaping with RTL direction.
        /// </summary>
        public Direction Direction
        {
            get => Api.hb_buffer_get_direction(Handle);
            set => Api.hb_buffer_set_direction(Handle, value);
        }

        /// <summary>
        ///     The script of buffer.
        ///     <br />
        ///     Script is crucial for choosing the proper shaping behaviour for scripts that require it (e.g. Arabic)
        ///     and the which OpenType features defined in the font to be applied.
        ///     <br />
        ///     You can pass one of the predefined <see cref="Script" /> values, or use
        ///     <see cref="HarfBuzz.Script.FromString(string)" /> or <see cref="HarfBuzz.Script.FromIso15924Tag(Tag)" /> to get the
        ///     corresponding script from an ISO 15924 script tag.
        /// </summary>
        public Tag Script
        {
            get => new Tag {Value = (uint) Api.hb_buffer_get_script(Handle)};
            set => Api.hb_buffer_set_script(Handle, (int) value.Value);
        }

        /// <summary>
        ///     The language of buffer. ISO 639 language code.
        ///     <br />
        ///     Languages are crucial for selecting which OpenType feature to apply to the buffer which can result in
        ///     applying language-specific behaviour. Languages are orthogonal to the scripts, and though they are
        ///     related, they are different concepts and should not be confused with each other.
        /// </summary>
        public string Language
        {
            get => Marshal.PtrToStringAnsi(Api.hb_language_to_string(Api.hb_buffer_get_language(Handle)));
            set
            {
                var bytes = Encoding.ASCII.GetBytes(value);
                Api.hb_buffer_set_language(Handle, Api.hb_language_from_string(bytes, bytes.Length));
            }
        }

        /// <summary>
        ///     Buffer flags.
        /// </summary>
        /// <seealso cref="HarfBuzz.Buffer.Flags" />
        public Flags Flags
        {
            get => Api.hb_buffer_get_flags(Handle);
            set => Api.hb_buffer_set_flags(Handle, value);
        }

        /// <summary>
        ///     Since 0.9.42
        /// </summary>
        public ClusterLevel ClusterLevel
        {
            get => Api.hb_buffer_get_cluster_level(Handle);
            set => Api.hb_buffer_set_cluster_level(Handle, value);
        }

        /// <summary>
        ///     Number of items in the buffer.
        /// </summary>
        public uint Length => Api.hb_buffer_get_length(Handle);

        /// <summary>
        ///     Since 0.9.2
        /// </summary>
        public Functions UnicodeFunctions
        {
            get => new Functions(Api.hb_buffer_get_unicode_funcs(Handle));
            set => Api.hb_buffer_set_unicode_funcs(Handle, value.Handle);
        }

        // todo user_data

        /// <summary>
        ///     Buffer glyph information array. Returned pointer is valid as long as buffer contents are not modified.
        /// </summary>
        public IEnumerable<GlyphInfo> GlyphInfos =>
            Api.hb_buffer_get_glyph_infos(Handle, out var length).AsUnmanagedArray<GlyphInfo>(length);

        /// <summary>
        ///     Buffer glyph position array. Returned pointer is valid as long as buffer contents are not modified.
        /// </summary>
        public IEnumerable<GlyphPosition> GlyphPositions =>
            Api.hb_buffer_get_glyph_positions(Handle, out var length).AsUnmanagedArray<GlyphPosition>(length);

        /// <summary>
        ///     The hb_codepoint_t that replaces invalid entries for a given encoding when adding text to buffer.
        ///     Default is <see cref="DefaultReplacementCodepoint" />.
        /// </summary>
        public uint ReplacementCodepoint
        {
            get => Api.hb_buffer_get_replacement_codepoint(Handle);
            set => Api.hb_buffer_set_replacement_codepoint(Handle, value);
        }

        #endregion
    }
}