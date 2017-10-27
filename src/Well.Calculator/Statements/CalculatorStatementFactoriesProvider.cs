using System.Collections.Generic;
using Well.Calculator.Statements.Assignment;
using Well.Calculator.Statements.Declaration;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;

namespace Well.Calculator.Statements
{
    public class CalculatorStatementFactoriesProvider : IStatementFactoriesProvider
    {
        public IEnumerable<IStatementFactory> GetStatementFactories()
        {
            yield return new DeclarationStatementFactory(this);
            yield return new AssignmentStatementFactory();
        }
    }
}