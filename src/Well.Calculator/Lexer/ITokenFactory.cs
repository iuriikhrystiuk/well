namespace Well.Calculator.Lexer
{
    public interface ITokenFactory
    {
        bool TryCreate(string input, out IToken token);
    }
}