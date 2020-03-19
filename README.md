# HardFuzz

[![Build status](https://ci.appveyor.com/api/projects/status/fhu6f4bjqiu0bj4e/branch/master?svg=true)](https://ci.appveyor.com/project/TJYSunset/hardfuzz/branch/master)
[![Unit test status](https://img.shields.io/appveyor/tests/TJYSunset/hardfuzz/master.svg)](https://ci.appveyor.com/project/TJYSunset/hardfuzz/branch/master/tests)
[![NuGet](https://img.shields.io/nuget/v/Sunsetware.HardFuzz.svg)](https://www.nuget.org/packages/Sunsetware.HardFuzz/)

Yet another [HarfBuzz](https://harfbuzz.github.io) C# binding. Intended to be a more complete alternative to [SharpFont.HarfBuzz](https://github.com/Robmaister/SharpFont.HarfBuzz) and [HarfBuzzSharp](https://github.com/mono/SkiaSharp/tree/master/binding).

.NET Standard 2.0. Not really tested on environment other than .NET Core 3.1 plus Windows 10 x64 though.

Native binaries not included; HarfBuzz provides [official builds](https://github.com/harfbuzz/harfbuzz/releases) for 32-bit Windows, while you can get my MinGW 64-bit build [here](HardFuzz.Test/TestData) (don't forget the other DLLs!)

**WIP**.

## Target HarfBuzz version

2.6.4

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
+ [hb-blob](https://harfbuzz.github.io/harfbuzz-hb-blob.html) (immutable only)
+ [hb-font](https://harfbuzz.github.io/harfbuzz-hb-font.html)
+ [hb-shape](https://harfbuzz.github.io/harfbuzz-Shaping.html)
  + `hb_font_destroy()`
+ [hb-ft](https://harfbuzz.github.io/harfbuzz-hb-ft.html)
  + `hb_ft_font_create()`

## Known issue(s)

+ FreeType integration doesn't seem to be working, please use blob instead
+ `hb_shape_list_shapers()` is bound using a dirty approach and has potential memory corruption risk

## Documentation

None at this point. Only some basic XML docs are present. Please refer to [HarfBuzz Manual](https://harfbuzz.github.io/).

## Usage

Please refer to the [unit test](HardFuzz.Test/HelloHarfBuzz.cs).

## To-do

+ Unicode functions
+ Maybe other features if someone asked me
+ Complete XML docs (`<param>` tags etc.)
+ Unit tests
+ Handle unmanaged errors more properly

## License

The library itself is [LGPL](COPYING.md). HarfBuzz is under its [own license](COPYING.HARFBUZZ). Other libraries/files' (if any) license information can be found in their own respective NuGet packages, in the directory containing them, etc.
