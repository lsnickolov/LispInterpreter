namespace LispInterpreter
{
    using System;
    using System.Collections.Generic;

    using LispInterpreter.Expressions;

    public static class Interpreter
    {
        static Interpreter()
        {
            Interpreter.GlobalScope = new Dictionary<string, Expression>();
            Reader = new ConsoleReader();
            Writer = new ConsoleWriter();
        }

        public static IReader Reader { get; set; }

        public static IWriter Writer { get; set; }

        private static IDictionary<string, Expression> GlobalScope { get; set; }

        public static void Run()
        {
            while (true)
            {
                IList<string> inputStatements = Reader.Read();

                foreach (string statement in inputStatements)
                {
                    IList<Token> tokens = Lexer.Scan(statement);
                    Expression expression = Parser.Parse((List<Token>)tokens);
                    Writer.Write(expression.Evaluate(GlobalScope));
                }
            }
        }
    }
}
