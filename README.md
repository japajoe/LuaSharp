# LuaSharp
A cross platform C# wrapper for Lua. Supports Windows, Linux and Mac.

# Dependencies
Build the native library found at https://github.com/japajoe/lua or check the releases.

# Example code

```csharp
using System;
using LuaSharp;

namespace LuaSharpApplication
{
    class Program
    {
        private static LuaFunction printFunction;

        //Example of how to call a C# function from Lua
        static void Main(string[] args)
        {
            LuaState state = Lua.NewState();
            Lua.OpenLibs(state);
            printFunction = Print;
            Lua.RegisterFunction(state, printFunction, "print");
            string code = "print('Hello world!')";

            if (Lua.DoString(state, code) != LuaResult.OK)
            {
                string error = Lua.ToString(state, -1);
                Console.WriteLine(error);
            }

            Lua.Close(state);            
        }

        private static int Print(LuaState s)
        {
            if(Lua.GetTop(s) != 1)
                return -1;

            string str = Lua.ToString(s, 1);

            Console.WriteLine(str);
            return 0;
        }
    }
}
```
