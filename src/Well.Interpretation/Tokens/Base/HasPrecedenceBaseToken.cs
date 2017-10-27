using Well.Interpretation.Evaluator;

namespace Well.Interpretation.Tokens.Base
{
    public abstract class HasPrecedenceBaseToken<TVisitor> : BaseToken, IHasPrecedence<TVisitor>
    {
        protected HasPrecedenceBaseToken(string tokenString) : base(tokenString)
        {
        }

        public abstract bool TryAccept(ITokenPrecedenceCounter<TVisitor> counter, out int precendence);
    }
}