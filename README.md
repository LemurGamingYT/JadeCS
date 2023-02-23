# Jade
- Jade is a programming language similar to Python in syntax and made in C#

## How to run
1. Download the .NET 7.0 (if you haven't already).
2. Run Jade.exe from a command line (The executable is located in /bin/Release/net7.0) and give the file
	- e.g. (inside ".\bin\Release\net7.0") `>.\Jade.exe examples/test.jd` - run the test file.  
3. Enjoy


# Ideas for this language

---

**Modules**
- Knock - A HTTP library
- CsSpeed - A library full of methods written in C# for maximum performance
- Json - JSON library support
- Time - A library for timing code blocks, functions, etc
- System - Like os and sys combined (from Python)
- JadeX - A library for creating programming languages
- FStream - FileIO
- Serializer - Serialization for Jade

---

**Built-in classes**
- Math (non-new able):
    - Math.Sine(int | float)
    - Math.Cosine(int | float)
    - Math.Min(int | float, int | float)
    - Math.Max(int | float, int | float)
- Random (non-new able):
  - Num(int)
    - Num(int, int)
  - Array(array)

---

**Built-in functions**
- Jade(*string*) -> *null* - execute a string
- Ascii(*string*) -> string - convert the to ascii/binary
- Attrs(*obj*) -> *any* - get the attributes of the object
- Any(*iterable*) -> *bool* - checks if any of the values in the iterable are true
- All(*iterable*) -> *bool* - checks if all the values in the iterable are true
- AllObjects() -> *array* - get all the objects in the global scope
- Setattr(*obj*, *string*, *any*) -> *null* - set an attribute on an object
- Getattr(*obj*, *string*) -> *any* - get an attribute of an object
- FunctionEnv(*function*) -> *any* - get the environment of a function as a dictionary
