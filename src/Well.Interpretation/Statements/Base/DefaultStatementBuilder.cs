using System.Collections.Generic;
using System.Linq;
using Well.Interpretation.Exceptions;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Statements.Base
{
    public class DefaultStatementBuilder : IStatementBuilder
    {
        private readonly IEnumerable<IStatementFactory> _factories;
        private IStatementFactory _currentStatementFactory;
        private IList<IToken> _currentTokens;

        public DefaultStatementBuilder(IStatementFactoriesProvider factoriesProvider)
        {
            _factories = factoriesProvider.GetStatementFactories();
        }

        public IStatementBuilder BeginStatement(IToken token)
        {
            _currentStatementFactory = _factories.FirstOrDefault(f => f.CanCreateStatement(token));
            if (_currentStatementFactory == null)
            {
                throw new InterpretationException($"Cannot determine statement from token {token}");
            }

            _currentTokens = new List<IToken>();
            return this;
        }

        public IStatementBuilder AcceptToken(IToken token)
        {
            if (_currentTokens != null)
            {
                _currentTokens.Add(token);
                return this;
            }
            
            throw new InterpretationException("The builder was not initialized by first token.");
        }

        public IStatement EndStatement()
        {
            if (_currentStatementFactory != null)
            {
                var statement = _currentStatementFactory.CreateStatement(_currentTokens);
                _currentStatementFactory = null;
                _currentTokens = null;
                return statement;
            }
            
            throw new InterpretationException("The builder was not initialized by first token.");
        }
    }
}