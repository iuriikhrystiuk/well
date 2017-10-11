using System.Text.RegularExpressions;
using Well.Calculator.Tokens.Base;

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