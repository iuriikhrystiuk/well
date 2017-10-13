using System.Collections.Generic;
using Well.Calculator.Tokens.Constant;
using Well.Calculator.Tokens.Declaration;
using Well.Calculator.Tokens.EndLine;
using Well.Calculator.Tokens.Operator;
using Well.Calculator.Tokens.Separator;
using Well.Calculator.Tokens.Variable;
using Well.Interpretation.Tokens;

namespace Well.Calculator.Tokens
{
    public class CalculatorTokensFactoryProvider : ITokenFactoriesProvider
    {
        public IEnumerable<ITokenFactory> GetTokenFactories()
        {
            yield return new DeclarationTokenFactory();
            yield return new OperatorTokenFactory();
            yield return new VariableTokenFactory();
            yield return new ConstantTokenFactory();
            yield return new SeparatorTokenFactory();
            yield return new EndLineTokenFactory();
        }
    }
}