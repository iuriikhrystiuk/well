using System.Collections.Generic;
using Well.Calculator.Statements.Declaration;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;

namespace Well.Calculator.Statements
{
    public class CalculatorStatementFactoriesProvider : IStatementFactoriesProvider
    {
        public IEnumerable<IStatementFactory> GetStatementFactories()
        {
            yield return new DeclarationStatementFactory();
        }
    }
}