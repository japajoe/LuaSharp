# LuaSharp
C# wrapper library for lua

```csharp
﻿using System;
using LuaSharp;

namespace LuaSharpApplication
{
    class Program
    {
        private static LuaState state = new LuaState();

        static void Main(string[] args)
        {
            if(Lua.Initialize(out state))
            {
                Lua.RegisterWriteLineCallback(OnWriteLine); //Bind the Lua print function to OnWriteLine

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
