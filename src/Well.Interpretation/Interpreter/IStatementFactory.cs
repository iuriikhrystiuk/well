using System.Collections.Generic;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Interpreter
{
    public interface IStatementFactory
    {
        bool CanCreateStatement(IToken token);

        IStatement CreateStatement(IToken token);
    }
}