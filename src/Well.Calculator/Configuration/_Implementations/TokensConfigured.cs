using Well.Calculator.Tokens;

namespace Well.Calculator.Configuration
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