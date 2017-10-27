using Well.Calculator.Evaluator;
using Well.Interpretation.Evaluator;
using Well.Interpretation.Tokens.Base;

namespace Well.Calculator.Tokens.Parentheses
{
    public class ParenthesesToken : HasPrecedenceBaseToken<ITokenPrecedenceVisitor>
    {
        public ParenthesesToken(string tokenString)
            : base(tokenString)
        {
        }

        public bool Opening => Value == "(";
        
        public override bool TryAccept(ITokenPrecedenceCounter<ITokenPrecedenceVisitor> counter, out int precendence)
        {
            return counter.GetVisitor().Visit(this, out precendence);
        }
    }
}