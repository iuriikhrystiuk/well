namespace Well.Interpretation.Tokens
{
    public interface IToken
    {
        bool SemanticallyEquals(IToken token);
    }
}