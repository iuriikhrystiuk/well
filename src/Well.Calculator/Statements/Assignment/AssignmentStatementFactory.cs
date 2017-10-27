using Well.Calculator.Evaluator;
using Well.Calculator.Tokens.Variable;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Statements.Assignment
{
    public class AssignmentStatementFactory : IStatementFactory
    {
        public bool CanCreateStatement(IToken token)
        {
            return token.GetType().IsAssignableFrom(typeof(VariableToken));
        }

        public IStatement CreateStatement(IToken token)
        {
            return new AssignmentStatement(token, new ExpressionBuilder<ITokenPrecedenceVisitor>(new TokenPrecedenceCounter()));
        }
    }
}