# HardFuzz

[![Build status](https://ci.appveyor.com/api/projects/status/fhu6f4bjqiu0bj4e/branch/master?svg=true)](https://ci.appveyor.com/project/TJYSunset/hardfuzz/branch/master)
[![Unit test status](https://img.shields.io/appveyor/tests/TJYSunset/hardfuzz/master.svg)](https://ci.appveyor.com/project/TJYSunset/hardfuzz/branch/master/tests)
[![NuGet](https://img.shields.io/nuget/v/Sunsetware.HardFuzz.svg)](https://www.nuget.org/packages/Sunsetware.HardFuzz/)
[![NuGet](https://img.shields.io/nuget/v/Sunsetware.HardFuzz.svg?label=nuget%3A%20SharpFont%20extension)](https://www.nuget.org/packages/Sunsetware.HardFuzz.SharpFont/)

Yet another [HarfBuzz](https://harfbuzz.github.io) C# binding. Intended to be a more complete alternative to [SharpFont.HarfBuzz](https://github.com/Robmaister/SharpFont.HarfBuzz) and [HarfBuzzSharp](https://github.com/mono/SkiaSharp/tree/master/binding).

.NET Standard 2.0. Not really tested on environment other than .NET Framework 4.7.1 plus Windows 10 x64 though.

**WIP**.

## Target HarfBuzz version

1.8.4

## What's implemented now

+ [hb-common](https://harfbuzz.github.io/harfbuzz-hb-common.html)
  + `hb_direction_t`
  + `hb_feature_t`
  + `hb_language_t`
  + `hb_script_t`
  + `hb_tag_t`
+ [hb-unicode](https://harfbuzz.github.io/harfbuzz-hb-unicode.html)
  + `hb_unicode_funcs_get_default()`
  + `hb_unicode_funcs_destroy()`
+ [hb-buffer](https://harfbuzz.github.io/harfbuzz-Buffers.html) (most of it's end-user-related part)
+ [hb-font](https://harfbuzz.github.io/harfbuzz-hb-font.html)
+ [hb-shape](https://harfbuzz.github.io/harfbuzz-Shaping.html)
  + `hb_font_destroy()`
+ [hb-ft](https://harfbuzz.github.io/harfbuzz-hb-ft.html) (utilizing third-party library [SharpFont](https://github.com/Robmaister/SharpFont))
  + `hb_ft_font_create()`

## Known issue(s)

+ `hb_shape_list_shapers()` is bound using a dirty approach and has potential memory corruption risk

## Documentation

None at this point. Only some basic XML docs are present. Please refer to [HarfBuzz Manual](https://harfbuzz.github.io/).

### Hello, HardFuzz [(see it in unit tests)](HardFuzz.Test/HelloHarfBuzz.cs)

```c#
using (var font = someSharpFontFace.ToHarfBuzzFont())
using (var buffer = new Buffer())
{
    buffer.AddUtf("Hello, HarfBuzz");
    buffer.GuessSegmentProperties();
    buffer.Shape(font);

    // the two properties are transparently bridged to unmanaged HarfBuzz buffers, thus can be considered costly to get
    var info = buffer.GlyphInfos.ToArray();
    var pos = buffer.GlyphPositions.ToArray();

    var cursorX = 0d;
    var cursorY = 0d;
    for (var i = 0; i < buffer.Length; i++)
    {
        var glyphId = info[i];
        var xOffset = pos[i].XOffset / 64d;
        var yOffset = pos[i].YOffset / 64d;
        var xAdvance = pos[i].XAdvance / 64d;
        var yAdvance = pos[i].YAdvance / 64d;

        // draw your glyph here

        cursorX += xAdvance;
        cursorY += yAdvance;
    }
}
```

## Help needed!

Seriously I failed to understand how the **** HarfBuzz and p/invoke work. Asking someone is way too much for my social skills. Pull requests & issues with implementation details will always be welcomed.

## To-do

+ Unicode functions
+ Maybe other features if someone asked me
+ Complete XML docs (`<param>` tags etc.)
+ Unit tests
+ Handle unmanaged errors more properly

## License

The library itself is [LGPL](COPYING.md). HarfBuzz is under its [own license](COPYING.HARFBUZZ). Other libraries/files' (if any) license information can be found in their own respective NuGet packages, in the directory containing them, etc.