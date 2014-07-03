namespace LispInterpreter.Expressions
{
    using System;
    using System.Collections.Generic;

    public class Multiplication : Expression
    {
        public Multiplication(List<Expression> arguments)
            : base(arguments)
        {
        }

        public override Expression Evaluate(IDictionary<string, Expression> scope)
        {
            double result = 1;

            foreach (Expression argument in this.arguments)
            {
                result *= Convert.ToDouble(argument.Evaluate(scope).Value);
            }

            if (IsInteger(result))
            {
                return new Integer((int)result);
            }
            else
            {
                return new Double(result);
            }
        }

        public override string ToString()
        {
            return string.Empty;
        }

        private static bool IsInteger(double number)
        {
            return (number % 1) == 0;
        }
    }
}
