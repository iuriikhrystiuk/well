using System.Collections.Generic;
using Well.Calculator.Tokens.Declaration;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Statements.Declaration
{
    public class DeclarationStatementFactory : IStatementFactory
    {
        public bool CanCreateStatement(IToken token)
        {
            return token.GetType().IsAssignableFrom(typeof(DeclarationToken));
        }

        public IStatement CreateStatement()
        {
            return new DeclarationStatement();
        }
    }
}