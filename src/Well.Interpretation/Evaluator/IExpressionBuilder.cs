using System.Collections.Generic;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Evaluator
{
    public interface IExpressionBuilder<TVisitor>
    {
        IExpression BuildExpression(IEnumerable<IHasPrecedence<TVisitor>> tokens);
    }
}