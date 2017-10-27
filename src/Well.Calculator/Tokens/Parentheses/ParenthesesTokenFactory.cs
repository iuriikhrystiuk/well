using System.Text.RegularExpressions;
using Well.Interpretation.Tokens;
using Well.Interpretation.Tokens.Base;

namespace Well.Calculator.Tokens.Parentheses
{
    public class ParenthesesTokenFactory: BaseTokenFactory
    {
        protected override Regex Tester => new Regex(@"^(\(|\))$");

        protected override IToken Create(string input)
        {
            return new ParenthesesToken(input);
        }
    }
}