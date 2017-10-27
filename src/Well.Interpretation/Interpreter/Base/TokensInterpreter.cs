using System.Collections.Generic;
using System.Linq;
using Well.Interpretation.Exceptions;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Interpreter.Base
{
    public class TokensInterpreter : ITokensInterpretation
    {
        private readonly IStatementFactoriesProvider _factoriesProvider;

        public TokensInterpreter(IStatementFactoriesProvider factoriesProvider)
        {
            _factoriesProvider = factoriesProvider;
        }

        public IEnumerable<IStatement> Interpret(IEnumerable<IToken> tokens, out IContext context)
        {
            context = null;
            var statements = new List<IStatement>();

            IStatement curreStatement = null;
            var tokensArray = tokens.ToArray();
            for (var i = 0; i < tokensArray.Length; i++)
            {
                var currentToken = tokensArray[i];
                if (curreStatement == null || curreStatement.Finished)
                {
                    var factory = _factoriesProvider.GetStatementFactories()
                        .FirstOrDefault(f => f.CanCreateStatement(currentToken));
                    if (factory == null)
                    {
                        throw new InterpretationException($"Cannot create statement from token {currentToken}");
                    }

                    curreStatement = factory.CreateStatement(currentToken);
                    statements.Add(curreStatement);
                }
                else
                {
                    if (!curreStatement.TryInjestToken(currentToken))
                    {
                        i--;
                    }
                }
            }

            return statements;
        }
    }
}