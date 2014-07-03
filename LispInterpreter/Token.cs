namespace LispInterpreter
{
    public class Token
    {
        public Token(string lexeme, TokenClass tokenClass)
        {
            this.Lexeme = lexeme;
            this.Class = tokenClass;
        }

        public string Lexeme { get; private set; }

        public TokenClass Class { get; private set; }
    }
}
