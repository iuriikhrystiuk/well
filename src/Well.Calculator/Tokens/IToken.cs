namespace Well.Calculator.Tokens
{
    public interface IToken
    {
        bool SemanticallyEquals(IToken token);
    }
}