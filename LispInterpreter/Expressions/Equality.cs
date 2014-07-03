namespace LispInterpreter.Expressions
{
    using System;
    using System.Collections.Generic;

    class Equality : Expression
    {
        public Equality(List<Expression> arguments)
            : base(arguments)
        {
        }

        public override Expression Evaluate(IDictionary<string, Expression> scope)
        {
            bool areEqual = true;
            decimal firstArgument = Convert.ToDecimal(arguments[0].Evaluate(scope).Value);

            for (int i = 1; i < arguments.Count; ++i)
            {
                decimal currentArgument = Convert.ToDecimal(arguments[i].Evaluate(scope).Value);
                areEqual &= (currentArgument == firstArgument);
            }

            return new Boolean(areEqual);
        }

        public override string ToString()
        {
            return string.Empty;
        }
    }
}
