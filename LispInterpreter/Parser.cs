namespace LispInterpreter
{
    using System.Collections.Generic;

    using LispInterpreter.Expressions;

    public static class Parser
    {
        public static Expression Parse(List<Token> tokens)
        {
            if (tokens.Count == 1)
            {
                return ExpressionBuilder.Build(tokens[0]);
            }

            List<Expression> arguments = new List<Expression>();
            for (int i = 2; i < tokens.Count - 1; ++i)
            {
                List<Token> currentArgumentTokens = new List<Token>();
                int balance = 0;

                do
                {
                    if (tokens[i].Class == TokenClass.OpeningParenthesis)
                    {
                        balance++;
                    }
                    else if (tokens[i].Class == TokenClass.ClosingParenthesis)
                    {
                        balance--;
                    }

                    currentArgumentTokens.Add(tokens[i]);
                    ++i;
                }
                while (i < tokens.Count - 1 && balance != 0);

                --i;
                arguments.Add(Parser.Parse(currentArgumentTokens));
            }

            return ExpressionBuilder.Build(tokens[1], arguments);
        }
    }
}
