using System.Text.RegularExpressions;
using Well.Interpretation.Tokens.Base;

namespace Well.Interpretation.Tokens.Variable
{
    public class VariableTokenFactory : BaseTokenFactory
    {
        protected override Regex Tester => new Regex(@"^([a-zA-Z]\w*)$");

        protected override IToken Create(string input)
        {
            return new VariableToken(input);
        }
    }
}