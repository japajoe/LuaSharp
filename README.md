# LuaSharp
A cross platform C# wrapper for Lua. Supports Windows, Linux and Mac.

# Dependencies
Build the native library found at https://github.com/japajoe/lua or check the releases.

# Example code

```csharp
﻿using System;
using LuaSharp;

namespace LuaSharpApplication
{
    class Program
    {
        private static LuaState state = new LuaState();
        private static LuaWriteLineCallback onWriteLine;

        static void Main(string[] args)
        {
            if(Lua.Initialize(out state))
            {
                onWriteLine = LuaDelegate.Create<LuaWriteLineCallback>(this, "OnWriteLine");
                Lua.RegisterWriteLineCallback(onWriteLine); //Bind the Lua print function to OnWriteLine

                string code = "print(\"Hello world!\")";
                LuaResult result = (LuaResult)Lua.DoString(out state, code);

                if (result != LuaResult.OK)
                {
                    string error = Lua.ToString(out state, -1);
                    Console.WriteLine(error);
                }

                Lua.Dispose(out state);
            }
        }

        private static void OnWriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
```
