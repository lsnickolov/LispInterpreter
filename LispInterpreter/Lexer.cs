namespace LispInterpreter
{
    using System;
    using System.Collections.Generic;

    public static class Lexer
    {
        static Lexer()
        {
            TokenTypes = new Dictionary<string, TokenClass>();

            Lexer.TokenTypes["("] = TokenClass.OpeningParenthesis;
            Lexer.TokenTypes[")"] = TokenClass.ClosingParenthesis;
            Lexer.TokenTypes["True"] = TokenClass.Boolean;
            Lexer.TokenTypes["False"] = TokenClass.Boolean;
            Lexer.TokenTypes["+"] = TokenClass.AdditionOperator;
            Lexer.TokenTypes["-"] = TokenClass.SubtractionOperator;
            Lexer.TokenTypes["*"] = TokenClass.MultiplicationOperator;
            Lexer.TokenTypes["/"] = TokenClass.DivisionOperator;
            Lexer.TokenTypes["="] = TokenClass.EqualityOperator;
            Lexer.TokenTypes["if"] = TokenClass.IfStatement;
        }

        public static IDictionary<string, TokenClass> TokenTypes { get; private set; }
        
        public static IList<Token> Scan(string statement)
        {
            IList<string> words = Split(statement);
            IList<Token> tokens = new List<Token>();

            foreach (string word in words)
            {
                TokenClass tokenClass = DetermineTokenClass(word);
                tokens.Add(new Token(word, tokenClass));
            }

            return tokens;
        }

        private static IList<string> Split(string statement)
        {
            IList<string> words = new List<string>();

            for (int i = 0; i < statement.Length; ++i)
            {
                if (IsParenthesis(statement[i]))
                {
                    words.Add(statement[i].ToString());
                }
                else
                {
                    string word = null;
                    if (IsStringOpening(statement[i]))
                    {
                        word = ReadStringLiteral(statement, i);
                    }
                    else if (!char.IsWhiteSpace(statement[i]))
                    {
                        word = ReadUntilEndOfWord(statement, i);
                    }

                    if (!string.IsNullOrEmpty(word))
                    {
                        words.Add(word);
                        i += word.Length - 1;
                    }
                }
            }

            return words;
        }

        private static bool IsParenthesis(char symbol)
        {
            return symbol == '(' || symbol == ')';
        }

        private static bool IsStringOpening(char symbol)
        {
            return symbol == '"';
        }

        private static string ReadStringLiteral(string statement, int startIndex)
        {
            int length = 1;
            while (!IsStringClosing(statement, startIndex + length))
            {
                length++;
            }

            return statement.Substring(startIndex, length + 1);
        }

        private static bool IsStringClosing(string statement, int index)
        {
            return statement[index] == '"' && statement[index - 1] != '\\';
        }

        private static string ReadUntilEndOfWord(string statement, int startIndex)
        {
            int length = 0;
            while (CanRead(startIndex, length, statement))
            {
                length++;
            }

            return statement.Substring(startIndex, length);
        }
  
        private static bool CanRead(int startIndex, int length, string statement)
        {
            return startIndex + length < statement.Length &&
                statement[startIndex + length] != '(' &&
                statement[startIndex + length] != ')' &&
                !char.IsWhiteSpace(statement[startIndex + length]);
        }

        private static TokenClass DetermineTokenClass(string word)
        {
            if (TokenTypes.ContainsKey(word))
            {
                return TokenTypes[word];
            }
            else if (IsString(word))
            {
                return TokenClass.String;
            }
            else if (IsInteger(word))
            {
                return TokenClass.Integer;
            }
            else if (IsDouble(word))
            {
                return TokenClass.Double;
            }

            return TokenClass.Identifier;
        }
  
        private static bool IsString(string word)
        {
            return word.Length >= 2 && word[0] == '"' && word[word.Length - 1] == '"';
        }

        private static bool IsInteger(string word)
        {
            int number;
            return int.TryParse(word, out number);
        }

        private static bool IsDouble(string word)
        {
            double number;
            return double.TryParse(word, out number);
        }
    }
}