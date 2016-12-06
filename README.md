# virutalq.NET
.NET Client for the virtualQ API

You can download the code and add the VirtualQNet project to your solution. Add a reference it by project.

## Usage

```cs

            var apiKey = "XXXXXXXX"; // Assign your API Key
            using (VirtualQ client = new VirtualQ(apiKey))
            {
                // Rest of the code ...
            }
```

## Build Instructions

1. Open the solution with Visual Studio 2015.
2. Select **"Release"** in Solution Configurations dropdown.
3. Build with `Ctrl` + `Shift` + `B`.

The assemblies will be located under `VirtualQNet\bin\Release`.
