# The Chronomancer — Slay the Spire 2 Mod

## Installation
1. Place both `ChronomancerMod.dll` and `ChronomancerMod.pck` in:  
   `<Steam>/steamapps/common/Slay the Spire 2/mods/ChronomancerMod/`
2. Also ensure `BaseLib.dll` and `BaseLib.pck` are in the `mods/` folder root.
3. Launch the game and enable the mod from the in-game mod list.

## Build From Source
To rebuild the DLL from the source project in `ChronomancerMod-Source/`:
1. Install [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
2. Install [MegaDot 4.5.1](https://github.com/Alchyr/ModTemplate-StS2/wiki) (Godot 4.5.1 mono build)
3. Set `GodotPath` in the `.csproj` to your MegaDot executable path
4. Run: `dotnet publish -c Release`
   - This compiles `ChronomancerMod.dll`
   - And exports `ChronomancerMod.pck` via MegaDot

Alternatively, the PCK can be regenerated at any time:
```
python3 generate_gdpc_pck.py ChronomancerMod.pck
```
