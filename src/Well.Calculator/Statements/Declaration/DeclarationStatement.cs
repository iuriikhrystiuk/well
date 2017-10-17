using System.Collections.Generic;
using Well.Calculator.Tokens.Declaration;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Statements.Declaration
{
    public class DeclarationStatement : IStatement
    {
        
        public bool TryInjestToken(IToken token)
        {
            switch (token.GetType())
            {
                case typeof(DeclarationToken):
                    
            }
        }

        public void Execute(IContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}