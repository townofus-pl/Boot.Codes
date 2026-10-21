# Boot.Codes

Boot.Codes is an Impostor plugin that reads lists of 6-letter words, and will assign them to lobbies when they are created. Once the lists are exhausted, game codes will be assigned "randomly", as usual.

> This is the `townofus-pl` fork of [miniduikboot/Boot.Codes](https://github.com/miniduikboot/Boot.Codes). Changes in 1.1.0: only 6-letter codes, lower case is accepted, and `#` starts a comment. See [Changes in this fork](#changes-in-this-fork).

The advantage of this is that you have more recognizable names for your games, which makes it easier to communicate codes to others.

## Installation

To install the plugin, you need [Impostor](https://github.com/Impostor/Impostor) 1.9.1 or newer. Tested with 1.10.9.

Build `Boot.Codes.dll` with `dotnet build -c Release Boot.Codes.csproj` (output in `bin/Release/net8.0/`) and put it in your `plugins` folder.

To make the plugin useful you need a list of game codes. You may write your own, or you could download one of the wordlists provided in [our repository](https://github.com/miniduikboot/Boot.Codes-lists).

When writing your own word lists, keep in mind that a code has exactly 6 letters from A up to and including Z. Lower case is read as upper case. Digits do not work: Among Us game codes have letters only.

Wordlists may include comments with a prefix of `#` or `--`. Lines starting with one of these are ignored. A line with a code may end with a comment, as long as the game code comes first:

```
# League lobbies
DRAMAA   # host 1
dramab   -- host 2
```

The wordlist(s) must be put in the server's directory in a folder called `Boot.Codes`. The full path is printed out when starting Impostor with the plugin installed.

### Usage

Once you have correctly installed it, you should see a message in the console when the server is starting, showing how many codes were loaded. If you see a message indicating that no codes were loaded, your wordlists are invalid. You may also see messages warning you of invalid codes.

If any codes were loaded, every new lobby will take a code from the lists randomly. Though, you can only have as many custom lobbies as you have words. Once there are more lobbies than the number of codes, normal codes will start being assigned again.

## Changes in this fork

- Only 6-letter codes. Among Us shows 6-letter codes. A 4-letter code is the old format, and a line with one shows a warning.
- Lower case codes are read as upper case.
- `#` starts a comment, next to the original `--`.
- Unit tests for the line parser (`dotnet test Boot.Codes.Tests`).

## Showcase

![](readme-resources/console.png)

![](readme-resources/game0.png)

![](readme-resources/game1.png)

![](readme-resources/game2.png)

## Credits

- Empireu for taking this plugin from the prototype stage to something useful.
- Minorusama for creating the API this plugin relies on.
