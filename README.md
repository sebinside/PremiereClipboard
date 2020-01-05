## PremiereClipboard

Premiere Clipboard is a small utility, which assists the user pasting prepared clipboards containing track items (clips) into Premiere. 
The usage of custom clips was first proposed by [Taran Van Hemert](https://www.youtube.com/watch?v=3ScBB7I1BEA) using [InsideClipboard](https://www.nirsoft.net/utils/inside_clipboard.html).
*InsideClipboard* is not optimized for Adobe Premiere and kinda hacky to use (e.g. additional clearing the clipboard is needed). Despite being freeware, it's also not open source.

**PremiereClipboard** solves these issues. It is possible to quickly store and load custom clipboard configurations containing premiere track items. 
At least on my system without the need of restarts or clearing the clipboard. This does simplify and speed up the process.

## Usage

The tool is written in C# to enable easy access to the windows clipboard. You can build the tool by yourself or simply download a [release](https://github.com/sebinside/PremiereClipboard/releases).
There is no GUI available, everything can be achieved using the command line interface.

The following output is printed when used with wrong arguments (shortened):
```
Usage: PremiereClipboard.exe <command> <filePath> <--overwrite>
Use command --save to store the copied track items to a specified file. By adding --overwrite as third parameter you disable the overwrite protection.
Use command --load to load previously stored track items from a specified file.
```

## More

This is my third small utility tool for working with Adobe Premiere and [Autohotkey](https://www.autohotkey.com/). Some more links, you might find interesting:

- **[AHK2PremiereCEP](https://github.com/sebinside/AHK2PremiereCEP)**, another utility tool from me. It helps you connect authotkey with the Adobe Premiere CEP scripting environment. Very helpful tool for video production.
- **[HotkeylessAHK](https://github.com/sebinside/HotkeylessAHK)**, my second utility tool. It enables calling AHK functions through HTTP GET requests. Very helpful e.g. for using Stream Decks.
- Taran Van Hemert, a macro specialist: https://www.youtube.com/user/TaranVH
- And my own twitch channel, where I develop with these techniques, sometimes: https://www.twitch.tv/skate702

If there are more questions, you can contact me on [Twitter](https://twitter.com/skate702) or via [mail](mailto:hi@sebinside.de).
