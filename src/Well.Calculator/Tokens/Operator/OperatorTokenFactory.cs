using System.Text.RegularExpressions;
using Well.Calculator.Tokens.Base;

namespace Well.Calculator.Tokens.Operator
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