# Empty Mod for Parkitect

This a minimimal example of a mod for [Parkitect][parkitect]. By itself, it does nothing. But, with your imagination - anything is possible.

I created this project because noone has explicitly written out the steps for creating a Parkitect mod. Huge shoutout to [Michael Pollind][pollend] for releasing their mods open source on Github, as well as the Parkitect discord community.

## Prerequisites

To make a Parkitect mod, you need four things:

- A copy of [Parkitect][parkitect]
- The .NET 4.5 SDK
- A C# Compiler
- A C# Disassembler

I used the DRM free version of Parkitect from [Humble Bundle][parkitect-humble], [Jetbrains dotPeek][dotpeek] for my disassembler, and [Visual Studio Community 2017] as my compiler - and the easiest way to install the .NET SDK.

## Project Setup

In Visual Studio, create a new Project.

Choose `C# Class Library (.NET Framework)` as the project type.

Fill in the Project name and Solution name to whatever you'd like your mod to be called.

Add refrences (`Project > Add Refrences...`) to some `.dll`s in the `Parkitect_Data/managed/` directory. You'll need at least `Parkitect.dll` and `UnityEngine.dll`. Optionally add `UnityEngine.CoreModule.dll` in order to log messages to Parkitect's debug console (press LEFT_ALT + LEFT_CTRL + D to toggle debug console)

In the Solution Explorer find each refrence you added and set `Copy Local` to `false`

Now, all that is required is to create a class that impliments IMod.

## Run & Debug

Currently working on this.

## Release & Publish to Steam

For now, you'll have to figure that out on your own.

[parkitect]: http://themeparkitect.com/
[parkitect-humble]: https://www.humblebundle.com/store/parkitect
[pollend]: https://github.com/pollend
[vscode]: https://code.visualstudio.com/
[vs2017]: https://visualstudio.microsoft.com/vs/community/
[dotpeek]: https://www.jetbrains.com/decompiler/
