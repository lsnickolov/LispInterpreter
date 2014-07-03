namespace LispInterpreter.Expressions
{
    using System.Collections.Generic;

    public abstract class Expression
    {
        protected readonly List<Expression> arguments;

        public Expression(List<Expression> arguments)
        {
            this.arguments = arguments;
            this.Scope = new Dictionary<string, Expression>();
        }

        public abstract Expression Evaluate(IDictionary<string, Expression> scope);

        public IDictionary<string, Expression> Scope { get; private set; }

        public object Value { get; protected set; }
    }
}
