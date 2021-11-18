using System;
using System.Runtime.InteropServices;

namespace LuaSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct lua_State
    {
        public IntPtr pointer;
    }
}
