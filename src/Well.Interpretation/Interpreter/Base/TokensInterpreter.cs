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
            List<IStatement> statements = new List<IStatement>();

            IStatement curreStatement = null;
            var tokensArray = tokens.ToArray();
            for (int i = 0; i < tokensArray.Length; i++)
            {
                if (curreStatement == null)
                {
                    var factory = _factoriesProvider.GetStatementFactories()
                        .FirstOrDefault(f => f.CanCreateStatement(tokensArray[i]));
                    if (factory == null)
                    {
                        throw new InterpretationException($"Cannot create statement from token {tokensArray[i]}");
                    }

                    curreStatement = factory.CreateStatement();
                }
                else
                {
                    if (!curreStatement.TryInjestToken(tokensArray[i]))
                    {
                        statements.Add(curreStatement);
                        curreStatement = null;
                        i--;
                    }
                }
            }

            return statements;
        }
    }
}