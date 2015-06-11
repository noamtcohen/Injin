# Injin
C# Runtime Dependency Injection in a Dependency Inverted Environment

Enables to swap dependencies at runtime from a configuration file where the running app has no compile time/source code dependencies on the implementations.

The [config.json](https://github.com/noamtcohen/Injin/blob/master/InjinClient/config.json) file is copied to the output directory.
Once you run the [console application](https://github.com/noamtcohen/Injin/tree/master/InjinClient), making changes to the config file will result in a different instance being created.

If you swap the underscore around, you will see the change reflected in the console
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
var fab = new Fabricator(Directory.GetCurrentDirectory() + "\\" + "config.json");

var foo = fab.Fabricate<IFoo>();
Console.WriteLine(foo.Hi());
```


