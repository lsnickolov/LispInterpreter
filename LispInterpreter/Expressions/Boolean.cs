namespace LispInterpreter.Expressions
{
    using System.Collections.Generic;

    public class Boolean : Expression
    {
        public Boolean(string valueAsString)
            : base(null)
        {
            if (valueAsString == "True")
            {
                this.Value = true;
            }
            else
            {
                this.Value = false;
            }
        }

        public Boolean(bool value)
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
