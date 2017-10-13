using System.Collections.Generic;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Interpreter.Base
{
    public class TokensInterpreter : ITokensInterpretation
    {
        private readonly IStatementBuilder _builder;

        public TokensInterpreter(IStatementBuilder builder)
        {
            _builder = builder;
        }

        public IEnumerable<IStatement> Interpret(IEnumerable<IToken> tokens, out IContext context)
        {
            context = null;
            
            foreach (var token in tokens)
            {
                
                
            }

            return null;
        }
    }
}