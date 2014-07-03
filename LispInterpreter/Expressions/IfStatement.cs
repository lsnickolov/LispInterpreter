namespace LispInterpreter.Expressions
{
    using System.Collections.Generic;

    public class IfStatement : Expression
    {
        public IfStatement(List<Expression> arguments)
            : base(arguments)
        {
        }

        public override Expression Evaluate(IDictionary<string, Expression> scope)
        {
            Expression predicate = arguments[0].Evaluate(scope);

            if ((bool)predicate.Value == true)
            {
                return arguments[1].Evaluate(scope);
            }
            else
            {
                return arguments[2].Evaluate(scope);
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
