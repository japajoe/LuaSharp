using System;
namespace LuaSharp
{
    public static class LuaDelegate
    {
        public static T Create<T>(Type typeOfDelegate, object target, string functionName) where T : Delegate
        {
            return (T)Delegate.CreateDelegate(typeOfDelegate, target, functionName, false);
        }

        public static Delegate Create(Type typeOfDelegate, object target, string functionName)
        {
            return Delegate.CreateDelegate(typeOfDelegate, target, functionName, false);
        }
    }
}