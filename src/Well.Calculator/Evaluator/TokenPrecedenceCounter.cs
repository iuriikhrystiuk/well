using System;
using Well.Calculator.Tokens.Operator;
using Well.Calculator.Tokens.Parentheses;
using Well.Interpretation.Evaluator;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Evaluator
{
    public class TokenPrecedenceCounter : ITokenPrecedenceCounter<ITokenPrecedenceVisitor>, ITokenPrecedenceVisitor
    {
        private int _currentTokenPrecedenceIncrement = 0;
        
        public bool TryGetPrecendece(IHasPrecedence<ITokenPrecedenceVisitor> token, out int precedence)
        {
            precedence = 0;
            if (token.TryAccept(this, out precedence))
            {
                precedence = precedence + _currentTokenPrecedenceIncrement;
                return true;
            }
            
            _currentTokenPrecedenceIncrement += precedence;
            return false;
        }

        public ITokenPrecedenceVisitor GetVisitor()
        {
            return this;
        }

        public bool Visit(ParenthesesToken token, out int precedence)
        {
            precedence = token.Opening ? 1 : -1;
            return true;
        }

        public bool Visit(OperatorToken token, out int precendence)
        {
            switch (token.OperatorType)
            {
                case OperatorToken.OperatorTypes.Plus:
                case OperatorToken.OperatorTypes.Minus:
                    precendence = 1;
                    return true;
                case OperatorToken.OperatorTypes.Multiply:
                case OperatorToken.OperatorTypes.Divide:
                    precendence = 2;
                    return true;
                default:
                    precendence = 0;
                    return false;
            }
        }
    }
}