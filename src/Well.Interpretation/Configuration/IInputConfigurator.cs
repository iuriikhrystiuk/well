using Well.Interpretation.Input;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.Configuration
{
    public interface IResolver
    {
        void Register<TInterface>(TInterface instance) where TInterface : class;
        
        TInterface Resolve<TInterface>() where TInterface: class;
    }
    
    public interface IInputConfigured : IResolver
    {
        IInput Input { get; }
    }

    public interface ITokensConfigured : IResolver
    {
        ITokenFactoriesProvider FactoriesProvider { get; }
    }
    
    public interface IStatementsConfigured : IResolver
    {
        IStatementFactoriesProvider FactoriesProvider { get; }
    }
}