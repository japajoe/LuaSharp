using System;
using System.Runtime.InteropServices;

namespace LuaSharp
{
    public delegate int LuaFunction(LuaState state);

    public static class Lua
    {
        const string NATIVELIBNAME = "lua";

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Call(IntPtr state, int numArgs, int numReturnValues);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_Close(IntPtr state);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_DoFile(IntPtr state, string filepath);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_DoString(IntPtr state, string code);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_FreeCharPointer(IntPtr ptr);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_GetArgumentCount(IntPtr state);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_GetGlobal(IntPtr state, string name);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_GetTable(IntPtr state, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_GetTop(IntPtr state);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsFunction(IntPtr state, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsNumber(IntPtr state, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsString(IntPtr state, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsTable(IntPtr state, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsUserData(IntPtr state, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr luaAPI_NewState();

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_OpenLibs(IntPtr state);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_PCall(IntPtr state, int numArgs, int numReturnValues, int errorHandlingType);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Pop(IntPtr state, int stackIndex);
        
        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushBool(IntPtr state, bool value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushFloat(IntPtr state, float value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushInt(IntPtr state, int value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushLightUserData(IntPtr state, IntPtr userData);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushString(IntPtr state, string value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Register_Function(IntPtr state, LuaFunction fn_ptr, string name);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_SetTop(IntPtr state, int stackIndex);           
        
        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_ToFloat(IntPtr state, int stackIndex, out float number);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_ToInt(IntPtr state, int stackIndex, out int number);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr luaAPI_ToString(IntPtr state, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr luaAPI_ToUserData(IntPtr state, int stackIndex);

        public static void Call(LuaState state, int numArgs, int numReturnValues)
        {
            luaAPI_Call(state.pointer, numArgs, numReturnValues);
        }

        public static bool Close(LuaState state)
        {
            return luaAPI_Close(state.pointer);
        }

        public static LuaResult DoFile(LuaState state, string filepath)
        {
            return (LuaResult)luaAPI_DoFile(state.pointer, filepath);
        }

        public static LuaResult DoString(LuaState state, string code)
        {
            return (LuaResult)luaAPI_DoString(state.pointer, code);
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

        public static bool IsUserData(LuaState state, int stackIndex)
        {
            return luaAPI_IsUserData(state.pointer, stackIndex);
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

        public static void PushLightUserData(LuaState state, IntPtr userData)
        {
            luaAPI_PushLightUserData(state.pointer, userData);
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

        public static T ToUserData<T>(LuaState state, int stackIndex)
        {
            IntPtr userData = luaAPI_ToUserData(state.pointer, stackIndex);
            GCHandle gch = GCHandle.FromIntPtr(userData);
            return (T)gch.Target;
        }
    }
}