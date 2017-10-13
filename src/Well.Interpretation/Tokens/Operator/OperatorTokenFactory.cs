using System.Text.RegularExpressions;
using Well.Interpretation.Tokens.Base;

namespace Well.Interpretation.Tokens.Operator
{
    public class OperatorTokenFactory : BaseTokenFactory
    {
        protected override Regex Tester => new Regex(@"^(\*|\\|\+|\-|=)$");

        protected override IToken Create(string input)
        {
            return new OperatorToken(input);
        }
    }
}