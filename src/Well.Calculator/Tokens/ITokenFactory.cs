namespace Well.Calculator.Tokens
{
    public interface ITokenFactory
    {
        bool TryCreate(string input, out IToken token);
    }
}