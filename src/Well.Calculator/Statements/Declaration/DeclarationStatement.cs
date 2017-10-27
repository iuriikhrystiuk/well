using System.Collections.Generic;
using System.Linq;
using Well.Calculator.Tokens.Declaration;
using Well.Calculator.Tokens.EndLine;
using Well.Calculator.Tokens.Iterator;
using Well.Calculator.Tokens.Separator;
using Well.Interpretation.Exceptions;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Statements.Declaration
{
    public class DeclarationStatement : IStatement
    {
        private readonly IStatementFactoriesProvider _provider;
        private bool _started;
        private readonly List<IStatement> _statements = new List<IStatement>();
        private IStatement _currentStatement;

        public DeclarationStatement(IToken token, IStatementFactoriesProvider provider)
        {
            _provider = provider;
            TryInjestToken(token);
        }

        public bool Finished { get; private set; }

        public bool TryInjestToken(IToken token)
        {
            switch (token.GetType().Name)
            {
                case nameof(DeclarationToken):
                    if (!_started)
                    {
                        _started = true;
                        return true;
                    }
                    return false;
                case nameof(SeparatorToken):
                    return true;
                case nameof(EndLineToken):
                    Finish();
                    return true;
                case nameof(IteratorToken):
                    if (_currentStatement != null && !_currentStatement.Finished)
                    {
                        _currentStatement.Finish();
                    }
                    return false;
                default:
                    if (_started && !Finished)
                    {
                        return TryInjectToken(token);
                    }
                    return false;
            }
        }

        public void Finish()
        {
            if (!Finished)
            {
                Finished = true;
            }
        }

        public void Execute(IContext context)
        {
            throw new System.NotImplementedException();
        }

        private bool TryInjectToken(IToken token)
        {
            if (_currentStatement == null || _currentStatement.Finished)
            {
                var factory = _provider.GetStatementFactories().FirstOrDefault(f => f.CanCreateStatement(token));
                if (factory == null)
                {
                    throw new InterpretationException($"Statement cannot be inferred from token {token}");
                }

                _currentStatement = factory.CreateStatement(token);
                _statements.Add(_currentStatement);
                return true;
            }

            return _currentStatement.TryInjestToken(token);
        }
    }
}