using System.Collections.Generic;

namespace Well.Interpretation.Tokens
{
    public interface ITokenFactoriesProvider
    {
        IEnumerable<ITokenFactory> GetTokenFactories();
    }
}