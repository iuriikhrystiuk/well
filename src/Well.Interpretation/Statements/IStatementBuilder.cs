using Well.Interpretation.Tokens;

namespace Well.Interpretation.Statements
{
    public interface IStatementBuilder
    {
        IStatementBuilder BeginStatement(IToken token);

        IStatementBuilder AcceptToken(IToken token);

        IStatement EndStatement();
    }
}