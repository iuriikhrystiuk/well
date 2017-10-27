namespace Well.Interpretation.Tokens
{
    public interface IToken
    {
        string Value { get; }
        
        bool SemanticallyEquals(IToken token);
    }
}