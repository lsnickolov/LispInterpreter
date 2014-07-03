namespace LispInterpreter.Expressions
{
    using System;
    using System.Collections.Generic;

    public class Division : Expression
    {
        public Division(List<Expression> arguments)
            : base(arguments)
        {
        }

        public override Expression Evaluate(IDictionary<string, Expression> scope)
        {
            double result = Convert.ToDouble(arguments[0].Evaluate(scope).Value);

            for (int i = 1; i < arguments.Count; ++i)
            {
                result /= Convert.ToDouble(arguments[i].Evaluate(scope).Value);
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
