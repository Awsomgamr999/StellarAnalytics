# StellarAnalytics

StellarAnalytics is a simple analytics mod for Kitten Space Agency that records how long the player has spent in the game across multiple sessions. It displays both the current session time and the total accumulated time directly in-game.

## Install

1. Go to [releases](https://github.com/Awsomgamr999/StellarAnalytics/releases/latest)
2. Download and extract the `.zip` file
3. Move the unzipped folder into the `Content\` folder of Kitten Space Agency
4. Edit the `Manifest.toml` in `\My Games\Kitten Space Agency\` and add the following:
```
[mods]
name = "StellarAnalytics"
enabled = true
```
5. Run KSA through [StarMap](https://github.com/StarMapLoader/StarMap/releases/latest)

## Features

### In-Game Time Display
- Shows the time spent in the current session.
- Shows the total time spent in the game across all sessions.
- Time is displayed in a Days:Hours:Minutes:Seconds format.

### NOTE
- This mod does save an additional file onto your computer. the file is called `timeFile.txt`. The purpose of this file is to save the amount of time that you have previously spent on the game to accurately tell you total time played.

**Location of file:**
`%LOCALAPPDATA%/KSA/StellarAnalytics/timeFile.txt`

## Source Code
The complete source code for StellarAnalytics is available on the [GitHub](https://github.com/Awsomgamr999/StellarAnalytics/tree/main).
