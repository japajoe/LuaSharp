using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LuaSharp
{
    public delegate void luaErrorCallback(string error);
    public delegate void luaWriteLineCallback(string error);
    public delegate int luaFunction(lua_State state);

    public static class Lua
    {
        private static StringBuilder stringBuilder = new StringBuilder(4096);
        private static IntPtr handle = IntPtr.Zero;

        const string NATIVELIBNAME = "lua";
        
        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Call(out IntPtr L, int numArgs, int numReturnValues);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_Dispose(out IntPtr L);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_DoFile(out IntPtr L, string filepath);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_DoString(out IntPtr L, string code);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_GetArgumentCount(out IntPtr L);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_GetGlobal(out IntPtr L, string name);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_GetTable(out IntPtr L, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_GetTop(out IntPtr L);
        
        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_Initialize(out IntPtr L);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsFunction(out IntPtr L, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsNumber(out IntPtr L, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsString(out IntPtr L, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern bool luaAPI_IsTable(out IntPtr L, int stackIndex);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern int luaAPI_PCall(out IntPtr L, int numArgs, int numReturnValues, int errorHandlingType);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Pop(out IntPtr L, int stackIndex);
        
        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushBool(out IntPtr L, bool value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushFloat(out IntPtr L, float value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushInt(out IntPtr L, int value);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_PushString(out IntPtr L, string value);        
        
        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Register_Error_Callback(luaErrorCallback callback);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Register_Function(out IntPtr L, luaFunction fn_ptr, string name);        

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Register_WriteLine_Callback(luaWriteLineCallback callback);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_SetTop(out IntPtr L, int stackIndex);           
        
        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_ToFloat(out IntPtr L, int stackIndex, out float number);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_ToInt(out IntPtr L, int stackIndex, out int number);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_ToString(out IntPtr L, int stackIndex, StringBuilder str);

        public static void Call(out lua_State state, int numArgs, int numReturnValues)
        {
            luaAPI_Call(out handle, numArgs, numReturnValues);
            state.pointer = handle;
        }

        public static bool Dispose(out lua_State state)
        {
            bool result = luaAPI_Dispose(out handle);
            state.pointer = handle;
            return result;
        }

        public static int DoFile(out lua_State state, string filepath)
        {
            int result = luaAPI_DoFile(out handle, filepath);
            state.pointer = handle;
            return result;
        }

        public static int DoString(out lua_State state, string code)
        {
            int result = luaAPI_DoString(out handle, code);
            state.pointer = handle;
            return result;
        }        

        public static int GetArgumentCount(out lua_State state)        
        {            
            int count = luaAPI_GetArgumentCount(out handle);
            state.pointer = handle;
            return count;
        }

        public static void GetGlobal(out lua_State state, string name)
        {
            luaAPI_GetGlobal(out handle, name);
            state.pointer = handle;
        }

        public static void GetTable(out lua_State state, int stackIndex)
        {
            luaAPI_GetTable(out handle, stackIndex);
            state.pointer = handle;
        }

        public static int GetTop(out lua_State state)
        {
            int result = luaAPI_GetTop(out handle);
            state.pointer = handle;
            return result;
        }

        public static bool Initialize(out lua_State state)
        {
            bool result = luaAPI_Initialize(out handle);
            state.pointer = handle;
            return result;
        }

        public static bool IsFunction(out lua_State state, int stackIndex)
        {
            bool result = luaAPI_IsFunction(out handle, stackIndex);
            state.pointer = handle;
            return result;
        }

        public static bool IsNumber(out lua_State state, int stackIndex)
        {
            bool result = luaAPI_IsNumber(out handle, stackIndex);
            state.pointer = handle;
            return result;
        }

        public static bool IsString(out lua_State state, int stackIndex)
        {
            bool result = luaAPI_IsString(out handle, stackIndex);
            state.pointer = handle;
            return result;
        }

        public static bool IsTable(out lua_State state, int stackIndex)
        {
            bool result = luaAPI_IsTable(out handle, stackIndex);
            state.pointer = handle;
            return result;
        }

        public static int PCall(out lua_State state, int numArgs, int numReturnValues, int errorHandlingType)
        {
            int result = luaAPI_PCall(out handle, numArgs, numReturnValues, errorHandlingType);
            state.pointer = handle;
            return result;
        }

        public static void Pop(out lua_State state, int stackIndex)
        {            
            luaAPI_Pop(out handle, stackIndex);
            state.pointer = handle;
        }

        public static void PushBool(out lua_State state, bool value)
        {
            luaAPI_PushBool(out handle, value);
            state.pointer = handle;
        }        

        public static void PushFloat(out lua_State state, float value)
        {
            luaAPI_PushFloat(out handle, value);
            state.pointer = handle;
        }

        public static void PushInt(out lua_State state, int value)
        {
            luaAPI_PushInt(out handle, value);
            state.pointer = handle;
        }  

        public static void PushNumber(out lua_State state, int value)
        {
            luaAPI_PushInt(out handle, value);
            state.pointer = handle;            
        }

        public static void PushNumber(out lua_State state, float value)
        {
            luaAPI_PushFloat(out handle, value);
            state.pointer = handle;            
        }

        public static void PushString(out lua_State state, string value)
        {            
            luaAPI_PushString(out handle, value);
            state.pointer = handle;
        }

        public static void RegisterErrorCallback(luaErrorCallback callback)
        {
            luaAPI_Register_Error_Callback(callback);
        }

        public static void RegisterFunction(out lua_State state, luaFunction fn_ptr, string name)
        {
            luaAPI_Register_Function(out handle, fn_ptr, name);
            state.pointer = handle;
        }        

        public static void RegisterWriteLineCallback(luaWriteLineCallback callback)
        {
            luaAPI_Register_WriteLine_Callback(callback);
        }       

        public static void SetTop(out lua_State state, int stackIndex)
        {
            luaAPI_SetTop(out handle, stackIndex);
            state.pointer = handle;
        }

        public static float ToFloat(out lua_State state, int stackIndex)
        {
            float result = 0;
            luaAPI_ToFloat(out handle, stackIndex, out result);
            state.pointer = handle;
            return result;
        }

        public static int ToInt(out lua_State state, int stackIndex)
        {
            int result = 0;
            luaAPI_ToInt(out handle, stackIndex, out result);
            state.pointer = handle;
            return result;
        }  

        public static string ToString(out lua_State state, int stackIndex)
        {
            string result = string.Empty;
            stringBuilder.Clear();
            stringBuilder.Append(result);
            luaAPI_ToString(out handle, stackIndex, stringBuilder);
            state.pointer = handle;
            return stringBuilder.ToString();
        }        
    }
}
