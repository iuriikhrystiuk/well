namespace Well.Calculator.Tokens.Base
{
    public abstract class BaseToken : IToken
    {
        private readonly string _tokenString;

        protected BaseToken(string tokenString)
        {
            _tokenString = tokenString;
        }

        public bool SemanticallyEquals(IToken token)
        {
            return token.GetType().IsAssignableFrom(GetType());
        }
    }
}