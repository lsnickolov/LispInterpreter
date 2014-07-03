namespace LispInterpreter
{
    using System.Collections.Generic;

    public interface IReader
    {
        IList<string> Read();
    }
}
