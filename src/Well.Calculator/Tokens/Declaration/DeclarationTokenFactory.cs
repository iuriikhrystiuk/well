using System.Text.RegularExpressions;
using Well.Interpretation.Tokens;
using Well.Interpretation.Tokens.Base;

namespace Well.Calculator.Tokens.Declaration
{
    public class DeclarationTokenFactory : BaseTokenFactory
    {
        protected override Regex Tester =>new Regex("^var$");
        
        protected override IToken Create(string input)
        {
            return new DeclarationToken(input);
        }
    }
}