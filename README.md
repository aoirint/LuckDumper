# Luck Dumper

Lethal Company Mod to dump luck values of unlockable items on using terminal.

## Development

Copy a DLL file into `libs/` from `C:\Program Files (x86)\Steam\steamapps\common\Lethal Company`.

- `Lethal Company_Data\Managed\Assembly-CSharp.dll`

### Build

```powershell
# Debug build
dotnet build

# Release build
dotnet build --configuration Release
```

### Install

### Debug build

Copy a DLL file into `C:\Program Files (x86)\Steam\steamapps\common\Lethal Company\BepInEx\plugins` from `bin\Debug\netstandard2.1\LuckDumper.dll`.

### Release build

Copy a DLL file into into `C:\Program Files (x86)\Steam\steamapps\common\Lethal Company\BepInEx\plugins` from `bin\Release\netstandard2.1\LuckDumper.dll`.

### r2modman

Select a DLL file from `Settings > Import local mod`.
