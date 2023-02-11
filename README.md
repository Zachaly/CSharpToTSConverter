# CSharpToTSConverter
 Program converting C# classes to TS interfaces

# Content requirements
 1. File can contain only one class
 2. Class can have only public fields

# Info about conversion
 1. `IEnumerable<T>` fields get converted to `T[]`
 2. `decimal`, `int` and `double` fields get converted to `number`
 3. `string` and other types are untouched
