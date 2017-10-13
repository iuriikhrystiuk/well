using System.Text.RegularExpressions;
using Well.Interpretation.Tokens;
using Well.Interpretation.Tokens.Base;

namespace Well.Calculator.Tokens.EndLine
{
    public class EndLineTokenFactory : BaseTokenFactory
    {
        protected override Regex Tester => new Regex(@"^(;)*$");
        
        protected override IToken Create(string input)
        {
            return new EndLineToken(input);
        }
    }
}