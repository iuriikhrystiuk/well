using Well.Interpretation.Interpreter;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Statements
{
    public interface IStatement
    {
        bool TryInjestToken(IToken token);
        
        void Execute(IContext context);
    }
}