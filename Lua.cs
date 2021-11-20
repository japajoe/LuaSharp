using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LuaSharp
{
    public delegate void LuaErrorCallback(string error);
    public delegate void LuaWriteLineCallback(string error);
    public delegate int LuaFunction(LuaState state);

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
        internal static extern void luaAPI_Register_Error_Callback(LuaErrorCallback callback);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Register_Function(out IntPtr L, LuaFunction fn_ptr, string name);        

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_Register_WriteLine_Callback(IntPtr callback);
//        internal static extern void luaAPI_Register_WriteLine_Callback(luaWriteLineCallback callback);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_SetTop(out IntPtr L, int stackIndex);           
        
        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_ToFloat(out IntPtr L, int stackIndex, out float number);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_ToInt(out IntPtr L, int stackIndex, out int number);

        [DllImport(NATIVELIBNAME, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void luaAPI_ToString(out IntPtr L, int stackIndex, StringBuilder str);

        public static void Call(out LuaState state, int numArgs, int numReturnValues)
        {
            luaAPI_Call(out handle, numArgs, numReturnValues);
            state.pointer = handle;
        }

        public static bool Dispose(out LuaState state)
        {
            bool result = luaAPI_Dispose(out handle);
            state.pointer = handle;
            return result;
        }

        public static int DoFile(out LuaState state, string filepath)
        {
            int result = luaAPI_DoFile(out handle, filepath);
            state.pointer = handle;
            return result;
        }

        public static int DoString(out LuaState state, string code)
        {
            int result = luaAPI_DoString(out handle, code);
            state.pointer = handle;
            return result;
        }        

        public static int GetArgumentCount(out LuaState state)        
        {            
            int count = luaAPI_GetArgumentCount(out handle);
            state.pointer = handle;
            return count;
        }

        public static void GetGlobal(out LuaState state, string name)
        {
            luaAPI_GetGlobal(out handle, name);
            state.pointer = handle;
        }

        public static void GetTable(out LuaState state, int stackIndex)
        {
            luaAPI_GetTable(out handle, stackIndex);
            state.pointer = handle;
        }

        public static int GetTop(out LuaState state)
        {
            int result = luaAPI_GetTop(out handle);
            state.pointer = handle;
            return result;
        }

        public static bool Initialize(out LuaState state)
        {
            bool result = luaAPI_Initialize(out handle);
            state.pointer = handle;
            return result;
        }

        public static bool IsFunction(out LuaState state, int stackIndex)
        {
            bool result = luaAPI_IsFunction(out handle, stackIndex);
            state.pointer = handle;
            return result;
        }

        public static bool IsNumber(out LuaState state, int stackIndex)
        {
            bool result = luaAPI_IsNumber(out handle, stackIndex);
            state.pointer = handle;
            return result;
        }

        public static bool IsString(out LuaState state, int stackIndex)
        {
            bool result = luaAPI_IsString(out handle, stackIndex);
            state.pointer = handle;
            return result;
        }

        public static bool IsTable(out LuaState state, int stackIndex)
        {
            bool result = luaAPI_IsTable(out handle, stackIndex);
            state.pointer = handle;
            return result;
        }

        public static int PCall(out LuaState state, int numArgs, int numReturnValues, int errorHandlingType)
        {
            int result = luaAPI_PCall(out handle, numArgs, numReturnValues, errorHandlingType);
            state.pointer = handle;
            return result;
        }

        public static void Pop(out LuaState state, int stackIndex)
        {            
            luaAPI_Pop(out handle, stackIndex);
            state.pointer = handle;
        }

        public static void PushBool(out LuaState state, bool value)
        {
            luaAPI_PushBool(out handle, value);
            state.pointer = handle;
        }        

        public static void PushFloat(out LuaState state, float value)
        {
            luaAPI_PushFloat(out handle, value);
            state.pointer = handle;
        }

        public static void PushInt(out LuaState state, int value)
        {
            luaAPI_PushInt(out handle, value);
            state.pointer = handle;
        }  

        public static void PushNumber(out LuaState state, int value)
        {
            luaAPI_PushInt(out handle, value);
            state.pointer = handle;            
        }

        public static void PushNumber(out LuaState state, float value)
        {
            luaAPI_PushFloat(out handle, value);
            state.pointer = handle;            
        }

        public static void PushString(out LuaState state, string value)
        {            
            luaAPI_PushString(out handle, value);
            state.pointer = handle;
        }

        public static void RegisterErrorCallback(LuaErrorCallback callback)
        {
            luaAPI_Register_Error_Callback(callback);
        }

        public static void RegisterFunction(out LuaState state, LuaFunction fn_ptr, string name)
        {
            luaAPI_Register_Function(out handle, fn_ptr, name);
            state.pointer = handle;
        }        

        public static void RegisterWriteLineCallback(LuaWriteLineCallback callback)
        {
            IntPtr ptr = ptr = Marshal.GetFunctionPointerForDelegate(callback);
            luaAPI_Register_WriteLine_Callback(ptr);
        }       

        public static void SetTop(out LuaState state, int stackIndex)
        {
            luaAPI_SetTop(out handle, stackIndex);
            state.pointer = handle;
        }

        public static float ToFloat(out LuaState state, int stackIndex)
        {
            float result = 0;
            luaAPI_ToFloat(out handle, stackIndex, out result);
            state.pointer = handle;
            return result;
        }

        public static int ToInt(out LuaState state, int stackIndex)
        {
            int result = 0;
            luaAPI_ToInt(out handle, stackIndex, out result);
            state.pointer = handle;
            return result;
        }  

        public static string ToString(out LuaState state, int stackIndex)
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
