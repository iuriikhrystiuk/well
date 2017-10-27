using System;
using System.Collections.Generic;
using Well.Calculator.Evaluator;
using Well.Calculator.Tokens.Declaration;
using Well.Calculator.Tokens.EndLine;
using Well.Calculator.Tokens.Iterator;
using Well.Calculator.Tokens.Operator;
using Well.Calculator.Tokens.Parentheses;
using Well.Calculator.Tokens.Separator;
using Well.Calculator.Tokens.Variable;
using Well.Interpretation.Evaluator;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Statements.Assignment
{
    public class AssignmentStatement : IStatement
    {
        private readonly IToken _assigningToken;
        private readonly List<IHasPrecedence<ITokenPrecedenceVisitor>> _tokens = new List<IHasPrecedence<ITokenPrecedenceVisitor>>();
        private readonly IExpressionBuilder<ITokenPrecedenceVisitor> _expressionBuilder;
        private IExpression _assignmentExpression;
        
        public AssignmentStatement(IToken token, IExpressionBuilder<ITokenPrecedenceVisitor> expressionBuilder)
        {
            _assigningToken = token;
            _expressionBuilder = expressionBuilder;
        }
        
        public bool Finished { get; private set; }

        public bool TryInjestToken(IToken token)
        {
            switch (token.GetType().Name)
            {
                case nameof(SeparatorToken):
                    return true;
                case nameof(OperatorToken):
                case nameof(VariableToken):
                case nameof(ParenthesesToken):
                    if (!Finished && TryPromoteToken(token, out var precedenceToken))
                    {
                        _tokens.Add(precedenceToken);
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        public void Finish()
        {
            if (!Finished)
            {
                _assignmentExpression = _expressionBuilder.BuildExpression(_tokens);
                Finished = true;
            }
        }

        public void Execute(IContext context)
        {
            throw new System.NotImplementedException();
        }

        private static bool TryPromoteToken(IToken token, out IHasPrecedence<ITokenPrecedenceVisitor> precedenceToken)
        {
            if (token is IHasPrecedence<ITokenPrecedenceVisitor> convertedToken)
            {
                precedenceToken = convertedToken;
                return true;
            }

            precedenceToken = null;
            return false;
        }
    }
}