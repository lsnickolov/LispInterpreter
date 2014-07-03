namespace LispInterpreter
{
    using System;

    using LispInterpreter.Expressions;

    public class ConsoleWriter : IWriter
    {
        public void Write(Expression evaluatedExpression)
        {
            Console.WriteLine(evaluatedExpression.Value);
        }
    }
}
