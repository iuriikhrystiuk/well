using Well.Interpretation.Interpreter;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Statements
{
    public interface IStatement
    {
        bool Finished { get; }
        
        bool TryInjestToken(IToken token);

        void Finish();
        
        void Execute(IContext context);
    }
}