using Well.Interpretation.Configuration._Implementations;
using Well.Interpretation.Input;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Configuration.Extensions
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

        public static IStatementsConfigured ConfigureStatements(this ITokensConfigured configurator, IStatementFactoriesProvider provider)
        {
            return new StatementsConfigured(configurator, provider);
        }
        
        public static IProcessor Build(this IStatementsConfigured tokensConfigured)
        {
            return tokensConfigured.Resolve<IProcessor>();
        }
    }
}