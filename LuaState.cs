using System;
using System.Runtime.InteropServices;

namespace LuaSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct LuaState
    {
        public IntPtr pointer;
    }
}
