using System.Collections.Generic;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Evaluator
{
    public interface IExpression
    {
        IEnumerable<IToken> GetMissingTokens();

        bool TryEvaluate<T>(IContext context, out T value);
    }
}