# Invert
C# Runtime Dependency Injection in a Dependency Inverted Environment

Enables to swap dependencies at runtime from a configuration file where the running app has no compile time/source code dependencies on the implementations.

The [config.json](https://github.com/noamtcohen/Invert/blob/master/InvertClient/config.json) file is copied to the output directory.
Once you run the [console application](https://github.com/noamtcohen/Invert/tree/master/InvertClient), making changes to the config file will result in a different instance being created. The [program](https://github.com/noamtcohen/Invert/blob/master/InvertClient/Program.cs) is running in an infinite loop, creating IFoo instances by the [Inverter](https://github.com/noamtcohen/Invert/blob/master/Invert/Inverter.cs) that are defined in the config file. The program has no reference to the implementation assemblies they are just placed in the bin dir to be probed by the CLR.

If you swap the underscore around, you will see the change reflected in the console in runtime.
```
{
    "_Interfaces.IFoo": {
        "AssemblyName": "A",
        "TypeName": "A.AFoo"
    },
    "Interfaces.IFoo": {
        "AssemblyName": "B",
        "TypeName": "B.BFoo"
    }
}
```
```csharp
var inv = new Inverter(Directory.GetCurrentDirectory() + "\\" + "config.json");

var foo = inv.Create<IFoo>();
Console.WriteLine(foo.Hi());
```


