using System.Collections.Generic;
using Well.Calculator.Tokens.Declaration;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Interpreter.Declaration
{
    public class DeclarationStatementFactory : IStatementFactory
    {
        public bool CanCreateStatement(IToken token)
        {
            return token.GetType().IsAssignableFrom(typeof(DeclarationToken));
        }

        public IStatement CreateStatement(IEnumerable<IToken> tokens)
        {
            return new DeclarationStatement(tokens);
        }
    }
}