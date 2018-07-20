using System;
using System.Runtime.InteropServices;
using HardFuzz.HarfBuzz;
using HardFuzz.HarfBuzz.Buffer;

// ReSharper disable InconsistentNaming

namespace HardFuzz.PlatformInvoke
{
    internal static partial class Api
    {
        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_buffer_create();

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_buffer_reference(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_buffer_get_empty();

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_destroy(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_reset(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_clear_contents(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern bool hb_buffer_pre_allocate(IntPtr buffer, uint size);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern bool hb_buffer_allocation_successful(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_add(IntPtr buffer, uint codepoint, uint cluster);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_add_codepoints(IntPtr buffer, uint[] text, int text_length,
            uint item_offset, int item_length);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_add_utf32(IntPtr buffer, uint[] text, int text_length, uint item_offset,
            int item_length);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_add_utf16(IntPtr buffer, ushort[] text, int text_length, uint item_offset,
            int item_length);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_add_utf8(IntPtr buffer, byte[] text, int text_length, uint item_offset,
            int item_length);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_add_latin1(IntPtr buffer, byte[] text, int text_length, uint item_offset,
            int item_length);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_append(IntPtr buffer, IntPtr source, uint start, uint end);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_set_content_type(IntPtr buffer, ContentType content_type);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern ContentType hb_buffer_get_content_type(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_set_direction(IntPtr buffer, Direction direction);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern Direction hb_buffer_get_direction(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_set_script(IntPtr buffer, int script);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern int hb_buffer_get_script(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern int hb_script_from_iso15924_tag(int tag);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern int hb_script_from_string(byte[] str, int len);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_set_language(IntPtr buffer, IntPtr language);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_buffer_get_language(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_language_from_string(byte[] str, int len);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_language_to_string(IntPtr language);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_set_flags(IntPtr buffer, Flags flags);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern Flags hb_buffer_get_flags(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_set_cluster_level(IntPtr buffer, ClusterLevel cluster_level);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern ClusterLevel hb_buffer_get_cluster_level(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern bool hb_buffer_set_length(IntPtr buffer, uint length);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern uint hb_buffer_get_length(IntPtr buffer);

        // omitted *[sg]et_segment_properties()

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_guess_segment_properties(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern bool hb_buffer_set_unicode_funcs(IntPtr buffer, IntPtr unicode_funcs);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_buffer_get_unicode_funcs(IntPtr buffer);

        // todo *[sg]et_user_data()

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_buffer_get_glyph_infos(IntPtr buffer, out uint length);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern IntPtr hb_buffer_get_glyph_positions(IntPtr buffer, out uint length);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_set_replacement_codepoint(IntPtr buffer, uint replacement);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern uint hb_buffer_get_replacement_codepoint(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_normalize_glyphs(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_reverse(IntPtr buffer);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_reverse_range(IntPtr buffer, uint start, uint end);

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern void hb_buffer_reverse_clusters(IntPtr buffer);

        // omitted ...serialize_format_(from|to)_string() & ...serialize_list_formats()

        // omitted ...segment_properties_(equal|hash)()

        // omitted ...set_message_func()

        [DllImport(HarfBuzzDll, CallingConvention = Cdecl)]
        public static extern GlyphFlags hb_glyph_info_get_glyph_flags(ref GlyphInfo info);

        // omitted ...message_func_t
    }
}