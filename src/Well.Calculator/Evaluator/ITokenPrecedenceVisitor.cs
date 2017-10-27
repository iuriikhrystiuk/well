using Well.Calculator.Tokens.Operator;
using Well.Calculator.Tokens.Parentheses;

namespace Well.Calculator.Evaluator
{
    public interface ITokenPrecedenceVisitor
    {
        bool Visit(ParenthesesToken token, out int precedence);

        bool Visit(OperatorToken token, out int precendence);
    }
}