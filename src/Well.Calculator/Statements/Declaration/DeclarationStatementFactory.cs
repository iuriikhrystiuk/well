using System.Collections.Generic;
using Well.Calculator.Tokens.Declaration;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Statements.Declaration
{
    public class DeclarationStatementFactory : IStatementFactory
    {
        private readonly IStatementFactoriesProvider _statementFactoriesProvider;

        public DeclarationStatementFactory(IStatementFactoriesProvider statementFactoriesProvider)
        {
            _statementFactoriesProvider = statementFactoriesProvider;
        }

        public bool CanCreateStatement(IToken token)
        {
            return token.GetType().IsAssignableFrom(typeof(DeclarationToken));
        }

        public IStatement CreateStatement(IToken token)
        {
            return new DeclarationStatement(token, _statementFactoriesProvider);
        }
    }
}