using Well.Interpretation.Interpreter;

namespace Well.Interpretation.Statements
{
    public interface IStatement
    {
        void Execute(IContext context);
    }
}