using System.Collections.Generic;
using Well.Interpretation.Configuration.Extensions;
using Well.Interpretation.Configuration._Implementations;
using Well.Interpretation.Exceptions;
using Well.Interpretation.Input._Implementations;
using Well.Interpretation.Tokens;
using Well.Interpretation.Tokens.Constant;
using Well.Interpretation.Tokens.Declaration;
using Well.Interpretation.Tokens.EndLine;
using Well.Interpretation.Tokens.Operator;
using Well.Interpretation.Tokens.Separator;
using Well.Interpretation.Tokens.Variable;
using Xunit;

namespace Well.Calculator.Tests
{
    public class ProcessorTests
    {
        private class DummyTokensProvider : ITokenFactoriesProvider
        {
            public IEnumerable<ITokenFactory> GetTokenFactories()
            {
                yield break;
            }
        }

        private class RealTokensProvider : ITokenFactoriesProvider
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
        
        [Fact]
        public void Process_Fails_Without_Tokens()
        {
            Assert.Throws<LexerException>(() => new Configurator()
                .ConfigureInput(new FileInput("TestCases/model.wc"))
                .ConfigureTokens(new DummyTokensProvider())
                .Build()
                .Process());
        }
        
        [Fact]
        public void Process_Succeeds_With_All_Tokens_In_Place()
        {
            var tokens = new Configurator()
                .ConfigureInput(new FileInput("TestCases/model.wc"))
                .ConfigureTokens(new RealTokensProvider())
                .Build()
                .Process();
            
            Assert.Equal(8, tokens.Count);
        }
    }
}