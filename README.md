![Finch logo](https://raw.githubusercontent.com/tomzorz/Finch/master/logo.png)

# Finch
A .net core library for nice console UI

[![Platform .net core](https://img.shields.io/badge/platform-dotnet--core-lightgray.svg?style=flat-squared)](https://github.com/tomzorz/Finch)
[![NuGet not yet](https://img.shields.io/badge/NuGet-not%20yet-red.svg?style=flat-squared)](https://github.com/tomzorz/Finch)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg?style=flat-squared)](https://github.com/tomzorz/Finch)

## Features

In order of implementation plans...

### Level 1: extended console interface

* move cursor around
* enable special formatting operators
* set colors
* etc...

### Level 2: screen buffer

* batch changes and flush them in one-call to the screen
* support for media content

### Level 3: GUI toolkit

* borders, windows, labels, buttons and more
* simple window management system
* maybe basic xaml support? 

## How to build

There's only a single extra thing to do: the demo project requires [ImageSharp](http://imagesharp.net/), which is still in prerelease. Until it's stable it'll only be available from its [MyGet](https://www.myget.org/gallery/imagesharp) feed, which you need to add to NuGet as a new source.

The feed URL: *https://www.myget.org/F/imagesharp/api/v3/index.json*

Steps:

* Right click on the solution / project
* Select "Manage NuGet packages..."
* Click on the little cogwheel (settings) icon in the top right
* Hit the green plus button
* Enter whatever as "name"
* Copy/paste the feed url into the "source" field
* Click on "Update" and on "OK"

The demo project should build successfully after this.

## FAQ

**NuGet?**

*Later-ish™*

**Why "Finch"?**

http://personofinterest.wikia.com/wiki/Harold_Finch

**Wasn't Finch a WindowsUI/Composition library before?**

Yes it was, but I abandoned that as the planned features either became part of the Windows SDK or the official WindowsUI toolkit.
