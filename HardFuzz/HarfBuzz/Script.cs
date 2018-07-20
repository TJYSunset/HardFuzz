using System.Text;
using HardFuzz.PlatformInvoke;

namespace HardFuzz.HarfBuzz
{
    /// <summary>
    ///     hb_script_t.
    ///     <br />
    ///     https://unicode.org/iso15924/
    ///     https://docs.google.com/spreadsheets/d/1Y90M0Ie3MUJ6UVCRDOypOtijlMDLNNyyLk36T6iMu0o
    ///     Unicode Character Database property: Script (sc)
    /// </summary>
    public static class Script
    {
        ///<summary>1.1</summary>
        public static readonly Tag Common = new Tag("Zyyy");

        ///<summary>1.1</summary>
        public static readonly Tag Inherited = new Tag("Zinh");

        ///<summary>5.0</summary>
        public static readonly Tag Unknown = new Tag("Zzzz");

        ///<summary>1.1</summary>
        public static readonly Tag Arabic = new Tag("Arab");

        ///<summary>1.1</summary>
        public static readonly Tag Armenian = new Tag("Armn");

        ///<summary>1.1</summary>
        public static readonly Tag Bengali = new Tag("Beng");

        ///<summary>1.1</summary>
        public static readonly Tag Cyrillic = new Tag("Cyrl");

        ///<summary>1.1</summary>
        public static readonly Tag Devanagari = new Tag("Deva");

        ///<summary>1.1</summary>
        public static readonly Tag Georgian = new Tag("Geor");

        ///<summary>1.1</summary>
        public static readonly Tag Greek = new Tag("Grek");

        ///<summary>1.1</summary>
        public static readonly Tag Gujarati = new Tag("Gujr");

        ///<summary>1.1</summary>
        public static readonly Tag Gurmukhi = new Tag("Guru");

        ///<summary>1.1</summary>
        public static readonly Tag Hangul = new Tag("Hang");

        ///<summary>1.1</summary>
        public static readonly Tag Han = new Tag("Hani");

        ///<summary>1.1</summary>
        public static readonly Tag Hebrew = new Tag("Hebr");

        ///<summary>1.1</summary>
        public static readonly Tag Hiragana = new Tag("Hira");

        ///<summary>1.1</summary>
        public static readonly Tag Kannada = new Tag("Knda");

        ///<summary>1.1</summary>
        public static readonly Tag Katakana = new Tag("Kana");

        ///<summary>1.1</summary>
        public static readonly Tag Lao = new Tag("Laoo");

        ///<summary>1.1</summary>
        public static readonly Tag Latin = new Tag("Latn");

        ///<summary>1.1</summary>
        public static readonly Tag Malayalam = new Tag("Mlym");

        ///<summary>1.1</summary>
        public static readonly Tag Oriya = new Tag("Orya");

        ///<summary>1.1</summary>
        public static readonly Tag Tamil = new Tag("Taml");

        ///<summary>1.1</summary>
        public static readonly Tag Telugu = new Tag("Telu");

        ///<summary>1.1</summary>
        public static readonly Tag Thai = new Tag("Thai");

        ///<summary>2.0</summary>
        public static readonly Tag Tibetan = new Tag("Tibt");

        ///<summary>3.0</summary>
        public static readonly Tag Bopomofo = new Tag("Bopo");

        ///<summary>3.0</summary>
        public static readonly Tag Braille = new Tag("Brai");

        ///<summary>3.0</summary>
        public static readonly Tag CanadianSyllabics = new Tag("Cans");

        ///<summary>3.0</summary>
        public static readonly Tag Cherokee = new Tag("Cher");

        ///<summary>3.0</summary>
        public static readonly Tag Ethiopic = new Tag("Ethi");

        ///<summary>3.0</summary>
        public static readonly Tag Khmer = new Tag("Khmr");

        ///<summary>3.0</summary>
        public static readonly Tag Mongolian = new Tag("Mong");

        ///<summary>3.0</summary>
        public static readonly Tag Myanmar = new Tag("Mymr");

        ///<summary>3.0</summary>
        public static readonly Tag Ogham = new Tag("Ogam");

        ///<summary>3.0</summary>
        public static readonly Tag Runic = new Tag("Runr");

        ///<summary>3.0</summary>
        public static readonly Tag Sinhala = new Tag("Sinh");

        ///<summary>3.0</summary>
        public static readonly Tag Syriac = new Tag("Syrc");

        ///<summary>3.0</summary>
        public static readonly Tag Thaana = new Tag("Thaa");

        ///<summary>3.0</summary>
        public static readonly Tag Yi = new Tag("Yiii");

        ///<summary>3.1</summary>
        public static readonly Tag Deseret = new Tag("Dsrt");

        ///<summary>3.1</summary>
        public static readonly Tag Gothic = new Tag("Goth");

        ///<summary>3.1</summary>
        public static readonly Tag OldItalic = new Tag("Ital");

        ///<summary>3.2</summary>
        public static readonly Tag Buhid = new Tag("Buhd");

        ///<summary>3.2</summary>
        public static readonly Tag Hanunoo = new Tag("Hano");

        ///<summary>3.2</summary>
        public static readonly Tag Tagalog = new Tag("Tglg");

        ///<summary>3.2</summary>
        public static readonly Tag Tagbanwa = new Tag("Tagb");

        ///<summary>4.0</summary>
        public static readonly Tag Cypriot = new Tag("Cprt");

        ///<summary>4.0</summary>
        public static readonly Tag Limbu = new Tag("Limb");

        ///<summary>4.0</summary>
        public static readonly Tag LinearB = new Tag("Linb");

        ///<summary>4.0</summary>
        public static readonly Tag Osmanya = new Tag("Osma");

        ///<summary>4.0</summary>
        public static readonly Tag Shavian = new Tag("Shaw");

        ///<summary>4.0</summary>
        public static readonly Tag TaiLe = new Tag("Tale");

        ///<summary>4.0</summary>
        public static readonly Tag Ugaritic = new Tag("Ugar");

        ///<summary>4.1</summary>
        public static readonly Tag Buginese = new Tag("Bugi");

        ///<summary>4.1</summary>
        public static readonly Tag Coptic = new Tag("Copt");

        ///<summary>4.1</summary>
        public static readonly Tag Glagolitic = new Tag("Glag");

        ///<summary>4.1</summary>
        public static readonly Tag Kharoshthi = new Tag("Khar");

        ///<summary>4.1</summary>
        public static readonly Tag NewTaiLue = new Tag("Talu");

        ///<summary>4.1</summary>
        public static readonly Tag OldPersian = new Tag("Xpeo");

        ///<summary>4.1</summary>
        public static readonly Tag SylotiNagri = new Tag("Sylo");

        ///<summary>4.1</summary>
        public static readonly Tag Tifinagh = new Tag("Tfng");

        ///<summary>5.0</summary>
        public static readonly Tag Balinese = new Tag("Bali");

        ///<summary>5.0</summary>
        public static readonly Tag Cuneiform = new Tag("Xsux");

        ///<summary>5.0</summary>
        public static readonly Tag Nko = new Tag("Nkoo");

        ///<summary>5.0</summary>
        public static readonly Tag PhagsPa = new Tag("Phag");

        ///<summary>5.0</summary>
        public static readonly Tag Phoenician = new Tag("Phnx");

        ///<summary>5.1</summary>
        public static readonly Tag Carian = new Tag("Cari");

        ///<summary>5.1</summary>
        public static readonly Tag Cham = new Tag("Cham");

        ///<summary>5.1</summary>
        public static readonly Tag KayahLi = new Tag("Kali");

        ///<summary>5.1</summary>
        public static readonly Tag Lepcha = new Tag("Lepc");

        ///<summary>5.1</summary>
        public static readonly Tag Lycian = new Tag("Lyci");

        ///<summary>5.1</summary>
        public static readonly Tag Lydian = new Tag("Lydi");

        ///<summary>5.1</summary>
        public static readonly Tag OlChiki = new Tag("Olck");

        ///<summary>5.1</summary>
        public static readonly Tag Rejang = new Tag("Rjng");

        ///<summary>5.1</summary>
        public static readonly Tag Saurashtra = new Tag("Saur");

        ///<summary>5.1</summary>
        public static readonly Tag Sundanese = new Tag("Sund");

        ///<summary>5.1</summary>
        public static readonly Tag Vai = new Tag("Vaii");

        ///<summary>5.2</summary>
        public static readonly Tag Avestan = new Tag("Avst");

        ///<summary>5.2</summary>
        public static readonly Tag Bamum = new Tag("Bamu");

        ///<summary>5.2</summary>
        public static readonly Tag EgyptianHieroglyphs = new Tag("Egyp");

        ///<summary>5.2</summary>
        public static readonly Tag ImperialAramaic = new Tag("Armi");

        ///<summary>5.2</summary>
        public static readonly Tag InscriptionalPahlavi = new Tag("Phli");

        ///<summary>5.2</summary>
        public static readonly Tag InscriptionalParthian = new Tag("Prti");

        ///<summary>5.2</summary>
        public static readonly Tag Javanese = new Tag("Java");

        ///<summary>5.2</summary>
        public static readonly Tag Kaithi = new Tag("Kthi");

        ///<summary>5.2</summary>
        public static readonly Tag Lisu = new Tag("Lisu");

        ///<summary>5.2</summary>
        public static readonly Tag MeeteiMayek = new Tag("Mtei");

        ///<summary>5.2</summary>
        public static readonly Tag OldSouthArabian = new Tag("Sarb");

        ///<summary>5.2</summary>
        public static readonly Tag OldTurkic = new Tag("Orkh");

        ///<summary>5.2</summary>
        public static readonly Tag Samaritan = new Tag("Samr");

        ///<summary>5.2</summary>
        public static readonly Tag TaiTham = new Tag("Lana");

        ///<summary>5.2</summary>
        public static readonly Tag TaiViet = new Tag("Tavt");

        ///<summary>6.0</summary>
        public static readonly Tag Batak = new Tag("Batk");

        ///<summary>6.0</summary>
        public static readonly Tag Brahmi = new Tag("Brah");

        ///<summary>6.0</summary>
        public static readonly Tag Mandaic = new Tag("Mand");

        ///<summary>6.1</summary>
        public static readonly Tag Chakma = new Tag("Cakm");

        ///<summary>6.1</summary>
        public static readonly Tag MeroiticCursive = new Tag("Merc");

        ///<summary>6.1</summary>
        public static readonly Tag MeroiticHieroglyphs = new Tag("Mero");

        ///<summary>6.1</summary>
        public static readonly Tag Miao = new Tag("Plrd");

        ///<summary>6.1</summary>
        public static readonly Tag Sharada = new Tag("Shrd");

        ///<summary>6.1</summary>
        public static readonly Tag SoraSompeng = new Tag("Sora");

        ///<summary>6.1</summary>
        public static readonly Tag Takri = new Tag("Takr");

        /// <summary>
        ///     No script set.
        /// </summary>
        public static readonly Tag Invalid = Tag.None;

        /// <summary>
        ///     Dummy values to ensure any <see cref="Tag" /> value can be passed/stored as <see cref="Script" />
        ///     without risking undefined behavior. Include both a signed and unsigned max,
        ///     since technically enums are int, and indeed, <see cref="Script" /> ends up being signed.
        ///     See this thread for technicalities:
        ///     https://lists.freedesktop.org/archives/harfbuzz/2014-March/004150.html
        /// </summary>
        public static readonly Tag Max = Tag.Max;

        /// <summary>
        ///     Dummy values to ensure any <see cref="Tag" /> value can be passed/stored as <see cref="Script" />
        ///     without risking undefined behavior. Include both a signed and unsigned max,
        ///     since technically enums are int, and indeed, <see cref="Script" /> ends up being signed.
        ///     See this thread for technicalities:
        ///     https://lists.freedesktop.org/archives/harfbuzz/2014-March/004150.html
        /// </summary>
        public static readonly Tag MaxSigned = Tag.MaxSigned;

        /// <summary>
        ///     Converts a string str representing an ISO 15924 script tag to a corresponding
        ///     <see cref="Script" />. Shorthand for hb_tag_from_string() then hb_script_from_iso15924_tag().
        /// </summary>
        public static Tag FromString(string str)
        {
            var bytes = Encoding.ASCII.GetBytes(str);
            return new Tag {Value = (uint) Api.hb_script_from_string(bytes, bytes.Length)};
        }

        /// <summary>
        ///     Converts an ISO 15924 script tag to a corresponding <see cref="Script" />.
        /// </summary>
        public static Tag FromIso15924Tag(Tag tag)
        {
            return new Tag {Value = (uint) Api.hb_script_from_iso15924_tag((int) tag.Value)};
        }

        #region Since 0.9.30

        ///<summary>7.0</summary>
        public static readonly Tag BassaVah = new Tag("Bass");

        ///<summary>7.0</summary>
        public static readonly Tag CaucasianAlbanian = new Tag("Aghb");

        ///<summary>7.0</summary>
        public static readonly Tag Duployan = new Tag("Dupl");

        ///<summary>7.0</summary>
        public static readonly Tag Elbasan = new Tag("Elba");

        ///<summary>7.0</summary>
        public static readonly Tag Grantha = new Tag("Gran");

        ///<summary>7.0</summary>
        public static readonly Tag Khojki = new Tag("Khoj");

        ///<summary>7.0</summary>
        public static readonly Tag Khudawadi = new Tag("Sind");

        ///<summary>7.0</summary>
        public static readonly Tag LinearA = new Tag("Lina");

        ///<summary>7.0</summary>
        public static readonly Tag Mahajani = new Tag("Mahj");

        ///<summary>7.0</summary>
        public static readonly Tag Manichaean = new Tag("Mani");

        ///<summary>7.0</summary>
        public static readonly Tag MendeKikakui = new Tag("Mend");

        ///<summary>7.0</summary>
        public static readonly Tag Modi = new Tag("Modi");

        ///<summary>7.0</summary>
        public static readonly Tag Mro = new Tag("Mroo");

        ///<summary>7.0</summary>
        public static readonly Tag Nabataean = new Tag("Nbat");

        ///<summary>7.0</summary>
        public static readonly Tag OldNorthArabian = new Tag("Narb");

        ///<summary>7.0</summary>
        public static readonly Tag OldPermic = new Tag("Perm");

        ///<summary>7.0</summary>
        public static readonly Tag PahawhHmong = new Tag("Hmng");

        ///<summary>7.0</summary>
        public static readonly Tag Palmyrene = new Tag("Palm");

        ///<summary>7.0</summary>
        public static readonly Tag PauCinHau = new Tag("Pauc");

        ///<summary>7.0</summary>
        public static readonly Tag PsalterPahlavi = new Tag("Phlp");

        ///<summary>7.0</summary>
        public static readonly Tag Siddham = new Tag("Sidd");

        ///<summary>7.0</summary>
        public static readonly Tag Tirhuta = new Tag("Tirh");

        ///<summary>7.0</summary>
        public static readonly Tag WarangCiti = new Tag("Wara");

        ///<summary>8.0</summary>
        public static readonly Tag Ahom = new Tag("Ahom");

        ///<summary>8.0</summary>
        public static readonly Tag AnatolianHieroglyphs = new Tag("Hluw");

        ///<summary>8.0</summary>
        public static readonly Tag Hatran = new Tag("Hatr");

        ///<summary>8.0</summary>
        public static readonly Tag Multani = new Tag("Mult");

        ///<summary>8.0</summary>
        public static readonly Tag OldHungarian = new Tag("Hung");

        ///<summary>8.0</summary>
        public static readonly Tag Signwriting = new Tag("Sgnw");

        #endregion

        #region Since 1.3.0

        ///<summary>9.0</summary>
        public static readonly Tag Adlam = new Tag("Adlm");

        ///<summary>9.0</summary>
        public static readonly Tag Bhaiksuki = new Tag("Bhks");

        ///<summary>9.0</summary>
        public static readonly Tag Marchen = new Tag("Marc");

        ///<summary>9.0</summary>
        public static readonly Tag Osage = new Tag("Osge");

        ///<summary>9.0</summary>
        public static readonly Tag Tangut = new Tag("Tang");

        ///<summary>9.0</summary>
        public static readonly Tag Newa = new Tag("Newa");

        #endregion

        #region Since 1.6.0

        ///<summary>10.0</summary>
        public static readonly Tag MasaramGondi = new Tag("Gonm");

        ///<summary>10.0</summary>
        public static readonly Tag Nushu = new Tag("Nshu");

        ///<summary>10.0</summary>
        public static readonly Tag Soyombo = new Tag("Soyo");

        ///<summary>10.0</summary>
        public static readonly Tag ZanabazarSquare = new Tag("Zanb");

        #endregion

        #region Since 1.8.0

        ///<summary>11.0</summary>
        public static readonly Tag Dogra = new Tag("Dogr");

        ///<summary>11.0</summary>
        public static readonly Tag GunjalaGondi = new Tag("Gong");

        ///<summary>11.0</summary>
        public static readonly Tag HanifiRohingya = new Tag("Rohg");

        ///<summary>11.0</summary>
        public static readonly Tag Makasar = new Tag("Maka");

        ///<summary>11.0</summary>
        public static readonly Tag Medefaidrin = new Tag("Medf");

        ///<summary>11.0</summary>
        public static readonly Tag OldSogdian = new Tag("Sogo");

        ///<summary>11.0</summary>
        public static readonly Tag Sogdian = new Tag("Sogd");

        #endregion
    }
}