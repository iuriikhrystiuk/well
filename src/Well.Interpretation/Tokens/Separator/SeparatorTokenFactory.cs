using System.Text.RegularExpressions;
using Well.Interpretation.Tokens.Base;

namespace Well.Interpretation.Tokens.Separator
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