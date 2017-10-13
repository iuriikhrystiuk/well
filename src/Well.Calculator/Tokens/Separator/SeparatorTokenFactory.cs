using System.Text.RegularExpressions;
using Well.Interpretation.Tokens;
using Well.Interpretation.Tokens.Base;

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