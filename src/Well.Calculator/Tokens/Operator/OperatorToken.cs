using System;
using System.Collections;
using System.Diagnostics;
using Well.Calculator.Evaluator;
using Well.Interpretation.Evaluator;
using Well.Interpretation.Tokens.Base;

namespace Well.Calculator.Tokens.Operator
{
    public class OperatorToken : HasPrecedenceBaseToken<ITokenPrecedenceVisitor>
    {
        public OperatorToken(string tokenString)
            : base(tokenString)
        {
        }

        public override bool TryAccept(ITokenPrecedenceCounter<ITokenPrecedenceVisitor> counter, out int precendence)
        {
            return counter.GetVisitor().Visit(this, out precendence);
        }

        public OperatorTypes OperatorType
        {
            get
            {
                switch (Value)
                {
                    case "+":
                        return OperatorTypes.Plus;
                    case "-":
                        return OperatorTypes.Minus;
                    case "*":
                        return OperatorTypes.Multiply;
                    case "/":
                        return OperatorTypes.Divide;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public enum OperatorTypes
        {
            Plus,
            Minus,
            Multiply,
            Divide
        }
    }
}