using System.Collections.Generic;
using Well.Calculator.Configuration;
using Well.Calculator.Configuration.Extensions;
using Well.Calculator.Exceptions;
using Well.Calculator.Input;
using Well.Calculator.Tokens;
using Well.Calculator.Tokens.Constant;
using Well.Calculator.Tokens.Declaration;
using Well.Calculator.Tokens.EndLine;
using Well.Calculator.Tokens.Operator;
using Well.Calculator.Tokens.Separator;
using Well.Calculator.Tokens.Variable;
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