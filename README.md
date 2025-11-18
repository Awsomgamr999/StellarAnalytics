# StellarAnalytics

StellarAnalytics is a simple analytics mod for Kitten Space Agency that records how long the player has spent in the game across multiple sessions. It displays both the current session time and the total accumulated time directly in-game.

## Features

### In-Game Time Display
- Shows the time spent in the current session.
- Shows the total time spent in the game across all sessions.
- Time is displayed in a Days:Hours:Minutes:Seconds format.

### Minimal & Safe Data Storage
- Saves only one value: the total accumulated playtime.
- Stored in a single text file named `timeFile.txt`.

**Location of saved data:**
`%LOCALAPPDATA%/KSA/StellarAnalytics/timeFile.txt`


### Data Safety Notes
- Only the total playtime (as a number) is saved.
- No personal information, logs, or extra files are created.
- Uses a safe writable directory so it works even if the game is installed in protected locations like Program Files.

## Source Code
The complete source code for StellarAnalytics is available on GitHub.
