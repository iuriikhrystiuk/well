using System.Collections.Generic;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Interpreter
{
    public interface ITokensInterpretation
    {
        IEnumerable<IStatement> Interpret(IEnumerable<IToken> tokens, out IContext context);
    }
}