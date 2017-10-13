using System.Collections.Generic;
using Well.Calculator.Interpreter.Declaration;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;

namespace Well.Calculator.Interpreter
{
    public class CalculatorStatementFactoriesProvider : IStatementFactoriesProvider
    {
        public IEnumerable<IStatementFactory> GetStatementFactories()
        {
            yield return new DeclarationStatementFactory();
        }
    }
}