using System.Text.RegularExpressions;
using Well.Calculator.Tokens.Operator;
using Well.Interpretation.Tokens;
using Well.Interpretation.Tokens.Base;

namespace Well.Calculator.Tokens.Iterator
{
    public class IteratorTokenFactory: BaseTokenFactory
    {
        protected override Regex Tester => new Regex(@"^,$");

        protected override IToken Create(string input)
        {
            return new OperatorToken(input);
        }
    }
}