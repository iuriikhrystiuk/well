using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Statements
{
    public abstract class BaseStatement : IStatement
    {
        public bool Finished { get; }
        public bool TryInjestToken(IToken token)
        {
            throw new System.NotImplementedException();
        }

        public void Finish()
        {
            throw new System.NotImplementedException();
        }

        public void Execute(IContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}