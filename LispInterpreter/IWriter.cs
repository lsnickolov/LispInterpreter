namespace LispInterpreter
{
    using LispInterpreter.Expressions;

    public interface IWriter
    {
        void Write(Expression evaluatedExpression);
    }
}
