using Well.Calculator.Input;
using Well.Calculator.Tokens;

namespace Well.Calculator.Configuration
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
}