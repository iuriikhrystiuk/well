namespace Well.Interpretation.Tokens
{
    public interface ITokenFactory
    {
        bool TryCreate(string input, out IToken token);
    }
}