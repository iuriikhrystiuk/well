using System.Text.RegularExpressions;

namespace Well.Interpretation.Tokens.Base
{
    public abstract class BaseTokenFactory : ITokenFactory
    {
        protected abstract Regex Tester { get; }

        public bool TryCreate(string input, out IToken token)
        {
            if (Tester.IsMatch(input))
            {
                token = Create(input);
                return true;
            }

            token = null;
            return false;
        }

        protected abstract IToken Create(string input);
    }
}