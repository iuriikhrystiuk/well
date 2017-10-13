using System.Collections.Generic;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Interpreter.Declaration
{
    public class DeclarationStatement : IStatement
    {
        private readonly IEnumerable<IToken> _tokens;

        public DeclarationStatement(IEnumerable<IToken> tokens)
        {
            _tokens = tokens;
        }

        public void Execute(IContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}