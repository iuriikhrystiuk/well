using System.Collections.Generic;

namespace Well.Calculator.Tokens
{
    public interface ITokenFactoriesProvider
    {
        IEnumerable<ITokenFactory> GetTokenFactories();
    }
}