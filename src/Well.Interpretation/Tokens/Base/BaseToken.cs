namespace Well.Interpretation.Tokens.Base
{
    public abstract class BaseToken : IToken
    {
        protected BaseToken(string tokenString)
        {
            Value = tokenString;
        }

        public string Value { get; }

        public bool SemanticallyEquals(IToken token)
        {
            return token.GetType().IsAssignableFrom(GetType());
        }
    }
}