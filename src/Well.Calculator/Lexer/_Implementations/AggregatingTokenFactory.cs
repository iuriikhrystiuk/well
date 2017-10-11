using System.Collections.Generic;

namespace Well.Calculator.Lexer
{
    public class AggregatingTokenFactory : ITokenFactory
    {
        private readonly IEnumerable<ITokenFactory> _factories;

        public AggregatingTokenFactory(IEnumerable<ITokenFactory> factories)
        {
            _factories = factories ?? new List<ITokenFactory>();
        }

        public bool TryCreate(string input, out IToken token)
        {
            foreach (var tokenFactory in _factories)
            {
                if (tokenFactory.TryCreate(input, out var createdToken))
                {
                    token = createdToken;
                    return true;
                }
            }

            token = null;
            return false;
        }
    }
}