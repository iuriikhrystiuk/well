using System.Text.RegularExpressions;
using Well.Calculator.Tokens.Base;

namespace Well.Calculator.Tokens.Separator
{
    public class SeparatorTokenFactory : BaseTokenFactory
    {
        protected override Regex Tester => new Regex(@"^(\s)*$");

        protected override IToken Create(string input)
        {
            return new SeparatorToken(input);
        }
    }
}