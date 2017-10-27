using Well.Interpretation.Evaluator;

namespace Well.Interpretation.Tokens
{
    public interface IHasPrecedence<TVisitor> : IToken
    {
        bool TryAccept(ITokenPrecedenceCounter<TVisitor> counter, out int precendence);
    }
}