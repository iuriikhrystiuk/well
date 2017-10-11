using Well.Calculator.Input;
using Well.Calculator.Tokens;

namespace Well.Calculator.Configuration.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IInputConfigured ConfigureInput(this Configurator configurator, IInput input)
        {
            return new InputConfigured(configurator, input);
        }
        
        public static ITokensConfigured ConfigureTokens(this IInputConfigured configurator, ITokenFactoriesProvider provider)
        {
            return new TokensConfigured(configurator, provider);
        }

        public static IProcessor Build(this ITokensConfigured tokensConfigured)
        {
            return tokensConfigured.Resolve<IProcessor>();
        }
    }
}