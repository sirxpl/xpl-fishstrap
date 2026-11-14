# XPLSTRAP Windows installer

XPLSTRAP publishes two Windows x64 executable names from one self-contained application build:

- **XPLSTRAP-Setup.exe** — the recommended first-download entry point. On a fresh machine/profile, launching it opens XPLSTRAP's built-in first-run installation wizard.
- **XPLSTRAP.exe** — the regular launcher executable. After installation, this is the executable installed into the XPLSTRAP application directory and used by shortcuts and Roblox protocol registration.

## Why the build artifact contains one executable

The setup executable is a separately named copy of the launcher, not a second installer implementation. Both files are byte-for-byte identical and use the same first-run installation flow, including language selection, install-location validation, shortcut creation, settings import, registry registration, and uninstall support.

To avoid storing and downloading two identical large executables, GitHub Actions uploads only **XPLSTRAP-Setup.exe** in its build artifact. The versioned GitHub Release workflow creates the **XPLSTRAP.exe** alias from that same file, so release downloads still provide both familiar filenames without duplicating the file in the Actions artifact.

Both names therefore refer to the same build and have the same XPLSTRAP icon, version, and behavior.

## Build locally

From a Windows machine with the .NET 6 SDK installed:

```powershell
dotnet restore
dotnet publish -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeAllContentForSelfExtract=true -r win-x64 -c Release --self-contained true .\Bloxstrap\Bloxstrap.csproj

$publishDir = ".\Bloxstrap\bin\Release\net6.0-windows\win-x64\publish"
Copy-Item "$publishDir\XPLSTRAP.exe" "$publishDir\XPLSTRAP-Setup.exe" -Force
```

The generated files are in the publish directory. The GitHub Actions workflow uploads one copy for build artifacts and creates both names for tagged releases.
