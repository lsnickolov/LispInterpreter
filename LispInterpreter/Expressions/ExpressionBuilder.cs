namespace LispInterpreter.Expressions
{
    using System.Collections.Generic;

    public static class ExpressionBuilder
    {
        public static Expression Build(Token root, List<Expression> arguments = null)
        {
            switch (root.Class)
            {
                case TokenClass.Boolean:
                    return new Boolean(root.Lexeme);
                case TokenClass.Integer:
                    return new Integer(root.Lexeme);
                case TokenClass.Double:
                    return new Double(root.Lexeme);
                case TokenClass.String:
                    return new String(root.Lexeme);
                case TokenClass.AdditionOperator:
                    return new Addition(arguments);
                case TokenClass.SubtractionOperator:
                    return new Subtraction(arguments);
                case TokenClass.MultiplicationOperator:
                    return new Multiplication(arguments);
                case TokenClass.DivisionOperator:
                    return new Division(arguments);
                case TokenClass.EqualityOperator:
                    return new Equality(arguments);
                case TokenClass.IfStatement:
                    return new IfStatement(arguments);
                default:
                    return null;
            }
        }
    }
}
