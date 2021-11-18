namespace LuaSharp
{    
    public enum LuaResult : int
    {
        OK = 0,
        YIELD = 1,
        ERRRUN = 2,
        ERRSYNTAX = 3,
        ERRMEM = 4,
        ERRERR = 5
    }
}
