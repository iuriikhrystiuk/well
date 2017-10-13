using Well.Interpretation.Statements;

namespace Well.Interpretation.Configuration._Implementations
{
    public class StatementsConfigured : BaseResolverDecorator, IStatementsConfigured
    {
        public StatementsConfigured(IResolver resolver, IStatementFactoriesProvider provider)
            : base(resolver)
        {
            FactoriesProvider = provider;
        }

        public IStatementFactoriesProvider FactoriesProvider { get; }
    }
}