namespace LispInterpreter.Expressions
{
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class String : Expression
    {
        public String(string value)
            : base(null)
        {
            this.Value = Regex.Unescape(value);
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
