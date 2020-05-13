## PremiereClipboard

Premiere Clipboard is a small utility, which assists the user pasting prepared clipboards containing track items (clips) into Premiere. 
The usage of custom clips was first proposed by [Taran Van Hemert](https://www.youtube.com/watch?v=3ScBB7I1BEA) using [InsideClipboard](https://www.nirsoft.net/utils/inside_clipboard.html).
*InsideClipboard* is not optimized for Adobe Premiere and kinda hacky to use. Despite being freeware, it's also not open source.

**PremiereClipboard** solves these issues. It is possible to quickly store and load custom clipboard configurations containing premiere track items.

## Usage

The tool is written in C# to enable easy access to the windows clipboard. You can build the tool by yourself or simply download a [release](https://github.com/sebinside/PremiereClipboard/releases).
There is no GUI available, everything can be achieved using the command line interface.

The following output is printed when used with wrong arguments (shortened):
```
Usage: PremiereClipboard.exe <command> <filePath>
Use command --save to store the copied track items to a specified file.
Use command --load to load previously stored track items from a specified file.
Use command --fill to fill clipboard with some text to avoid some weird premiere bug.
```

For more information about the `--fill` command, please see below.

## Usage with AutoHotkey and AHK2PremiereCEP

PremiereClipboard integrates well with AutoHotkey and my existing Framework [AHK2PremiereCEP](https://github.com/sebinside/AHK2PremiereCEP). In short:

```autoit
LoadPremiereClipboard(clipName) {

  ; Additional effort (see below)

  RunWait, %comspec% /c <PathToPremiereClipboard>\PremiereClipboard.exe --load <PathToClipboards>\%clipName%
  
  ; Pasting the clipboard inside Premiere
  }
```

A full working example can be found in my [AutoHotkey Script Dump](https://github.com/sebinside/AutoHotkeyScripts/blob/860bc292ca209eb88665a61d51683b494c780c83/StreamDeckFunctions.ahk#L192).

Its often also quite usefull to select the target tracks of Premiere prior to pasting to ensure that nothing gets overwritten. I already implemented a prototype, please see [here](https://github.com/sebinside/AHK2PremiereCEP/blob/775bf3e22b488090a1438bb7cfdda936e01f22bc/host/index.tsx#L292).

## Premiere's clipboard issue and the --fill command

It has already been [discovered](https://youtu.be/ofyJ-qfv1cI) that Premiere Pro treats the clipboard in some... special way. Unfortunately, PremiereClipboard is also affected by this behaviour. 

The current solution (which works for 100% in Premiere Pro 2020) is to use the `--fill` command to load some text into the clipboard. By then tabbing out and in the Premiere window, some reload action is triggered. Afterwards, the track items can be safely loaded to the clipboard and pasted using AHK.

This is the current state of development. If you've found more information regarding this problem, feel free to open a github issue.

## More

This is my third small utility tool for working with Adobe Premiere and [Autohotkey](https://www.autohotkey.com/). Some more links, you might find interesting:

- **[AHK2PremiereCEP](https://github.com/sebinside/AHK2PremiereCEP)**, another utility tool from me. It helps you connect authotkey with the Adobe Premiere CEP scripting environment. Very helpful tool for video production.
- **[HotkeylessAHK](https://github.com/sebinside/HotkeylessAHK)**, my second utility tool. It enables calling AHK functions through HTTP GET requests. Very helpful e.g. for using Stream Decks.
- Taran Van Hemert, a macro specialist: https://www.youtube.com/user/TaranVH
- And my own twitch channel, where I develop with these techniques, sometimes: https://www.twitch.tv/skate702

If there are more questions, you can contact me on [Twitter](https://twitter.com/skate702) or via [mail](mailto:hi@sebinside.de).
