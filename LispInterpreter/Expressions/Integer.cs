namespace LispInterpreter.Expressions
{
    using System.Collections.Generic;

    public class Integer : Expression
    {
        public Integer(string valueAsString)
            : base(null)
        {
            this.Value = int.Parse(valueAsString);
        }

        public Integer(int value)
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
