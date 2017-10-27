using System.Collections.Generic;
using Well.Interpretation.Evaluator;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Evaluator
{
    public class ExpressionBuilder<TVisitor> : IExpressionBuilder<TVisitor>
    {
        private readonly ITokenPrecedenceCounter<TVisitor> _counter;

        public ExpressionBuilder(ITokenPrecedenceCounter<TVisitor> counter)
        {
            _counter = counter;
        }

        public IExpression BuildExpression(IEnumerable<IHasPrecedence<TVisitor>> tokens)
        {
            Dictionary<IHasPrecedence<TVisitor>, int> priorityMap = new Dictionary<IHasPrecedence<TVisitor>, int>();

            foreach (var hasPrecedence in tokens)
            {
                if (_counter.TryGetPrecendece(hasPrecedence, out var priority))
                {
                    priorityMap.Add(hasPrecedence, priority);
                }
            }
            
            return null;
        }
    }
}