using System.Collections.Generic;
using Well.Interpretation.Interpreter;

namespace Well.Interpretation.Statements
{
    public interface IStatementFactoriesProvider
    {
        IEnumerable<IStatementFactory> GetStatementFactories();
    }
}