namespace LispInterpreter.Expressions
{
    using System.Collections.Generic;

    public class Double : Expression
    {
        public Double(string valueAsString)
            : base(null)
        {
            this.Value = double.Parse(valueAsString);
        }

        public Double(double value)
            : base(null)
        {
            this.Value = value;
        }

        public override Expression Evaluate(IDictionary<string, Expression> scope)
        {
            return this;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
