using Well.Interpretation.Tokens;

namespace Well.Interpretation.Configuration._Implementations
{
    public class TokensConfigured : BaseResolverDecorator, ITokensConfigured
    {
        public TokensConfigured(IInputConfigured configurator, ITokenFactoriesProvider factoriesProvider)
            : base(configurator)
        {
            FactoriesProvider = factoriesProvider;
            Register(factoriesProvider);
        }

        public ITokenFactoriesProvider FactoriesProvider { get; }
    }
}