using Well.Interpretation.Tokens;

namespace Well.Interpretation.Evaluator
{
    public interface ITokenPrecedenceCounter<TVisitor>
    {
        bool TryGetPrecendece(IHasPrecedence<TVisitor> token, out int precedence);

        TVisitor GetVisitor();
    }
}