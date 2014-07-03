namespace LispInterpreter
{
    using System;
    using System.Collections.Generic;

    public class ConsoleReader : IReader
    {
        public IList<string> Read()
        {
            List<string> statements = new List<string>();
            statements.Add(Console.ReadLine());

            return statements;
        }
    }
}
