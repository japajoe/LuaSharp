using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LuaSharp
{
    public delegate int LuaFunction(LuaState state);

    public static class Lua
    {
        private static StringBuilder stringBuilder = new StringBuilder(4096);

        const string NATIVELIBNAME = "lua";

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Call(IntPtr L, int numArgs, int numReturnValues);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_Close(IntPtr L);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_DoFile(IntPtr L, string filepath);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_DoString(IntPtr L, string code);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_FreeCharPointer(IntPtr ptr);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_GetArgumentCount(IntPtr L);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_GetGlobal(IntPtr L, string name);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_GetTable(IntPtr L, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_GetTop(IntPtr L);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsFunction(IntPtr L, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsNumber(IntPtr L, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsString(IntPtr L, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsTable(IntPtr L, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr luaAPI_NewState();

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_OpenLibs(IntPtr L);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_PCall(IntPtr L, int numArgs, int numReturnValues, int errorHandlingType);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Pop(IntPtr L, int stackIndex);
        
        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushBool(IntPtr L, bool value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushFloat(IntPtr L, float value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushInt(IntPtr L, int value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushString(IntPtr L, string value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Register_Function(IntPtr L, LuaFunction fn_ptr, string name);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_SetTop(IntPtr L, int stackIndex);           
        
        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_ToFloat(IntPtr L, int stackIndex, out float number);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_ToInt(IntPtr L, int stackIndex, out int number);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr luaAPI_ToString(IntPtr L, int stackIndex);

        public static void Call(LuaState state, int numArgs, int numReturnValues)
        {
            luaAPI_Call(state.pointer, numArgs, numReturnValues);
        }

        public static bool Close(LuaState state)
        {
            return luaAPI_Close(state.pointer);
        }

        public static int DoFile(LuaState state, string filepath)
        {
            return luaAPI_DoFile(state.pointer, filepath);
        }

        public static int DoString(LuaState state, string code)
        {
            return luaAPI_DoString(state.pointer, code);
        }        

        public static int GetArgumentCount(LuaState state)        
        {            
            return luaAPI_GetArgumentCount(state.pointer);
        }

        public static void GetGlobal(LuaState state, string name)
        {
            luaAPI_GetGlobal(state.pointer, name);
        }

        public static void GetTable(LuaState state, int stackIndex)
        {
            luaAPI_GetTable(state.pointer, stackIndex);
        }

        public static int GetTop(LuaState state)
        {
            return luaAPI_GetTop(state.pointer);
        }

        public static bool IsFunction(LuaState state, int stackIndex)
        {
            return luaAPI_IsFunction(state.pointer, stackIndex);
        }

        public static bool IsNumber(LuaState state, int stackIndex)
        {
            return luaAPI_IsNumber(state.pointer, stackIndex);
        }

        public static bool IsString(LuaState state, int stackIndex)
        {
            return luaAPI_IsString(state.pointer, stackIndex);
        }

        public static bool IsTable(LuaState state, int stackIndex)
        {
            return luaAPI_IsTable(state.pointer, stackIndex);
        }

        public static LuaState NewState()
        {
            IntPtr handle = luaAPI_NewState();
            LuaState state = new LuaState();
            state.pointer = handle;
            return state;
        }

        public static void OpenLibs(LuaState state)
        {
            luaAPI_OpenLibs(state.pointer);
        }

        public static int PCall(LuaState state, int numArgs, int numReturnValues, int errorHandlingType)
        {
            return luaAPI_PCall(state.pointer, numArgs, numReturnValues, errorHandlingType);
        }

        public static void Pop(LuaState state, int stackIndex)
        {            
            luaAPI_Pop(state.pointer, stackIndex);
        }

        public static void PushBool(LuaState state, bool value)
        {
            luaAPI_PushBool(state.pointer, value);
        }        

        public static void PushFloat(LuaState state, float value)
        {
            luaAPI_PushFloat(state.pointer, value);
        }

        public static void PushInt(LuaState state, int value)
        {
            luaAPI_PushInt(state.pointer, value);
        }  

        public static void PushNumber(LuaState state, int value)
        {
            luaAPI_PushInt(state.pointer, value);            
        }

        public static void PushNumber(LuaState state, float value)
        {
            luaAPI_PushFloat(state.pointer, value);            
        }

        public static void PushString(LuaState state, string value)
        {            
            luaAPI_PushString(state.pointer, value);
        }

        public static void RegisterFunction(LuaState state, LuaFunction fn_ptr, string name)
        {
            luaAPI_Register_Function(state.pointer, fn_ptr, name);
        }       

        public static void SetTop(LuaState state, int stackIndex)
        {
            luaAPI_SetTop(state.pointer, stackIndex);
        }

        public static float ToFloat(LuaState state, int stackIndex)
        {
            luaAPI_ToFloat(state.pointer, stackIndex, out float result);
            return result;
        }

        public static int ToInt(LuaState state, int stackIndex)
        {
            luaAPI_ToInt(state.pointer, stackIndex, out int result);
            return result;
        }  

        public static string ToString(LuaState state, int stackIndex)
        {
            IntPtr str = luaAPI_ToString(state.pointer, stackIndex);
            string text = Marshal.PtrToStringAuto(str);
            luaAPI_FreeCharPointer(str);
            return text;
        }
    }
}
