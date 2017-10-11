using System.Text.RegularExpressions;
using Well.Calculator.Tokens.Base;

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