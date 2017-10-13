using System.Collections.Generic;
using Well.Calculator.Interpreter;
using Well.Calculator.Tokens;
using Well.Interpretation.Configuration.Extensions;
using Well.Interpretation.Configuration._Implementations;
using Well.Interpretation.Exceptions;
using Well.Interpretation.Input._Implementations;
using Well.Interpretation.Interpreter;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;
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
        
        private class DummyStatementProvider : IStatementFactoriesProvider
        {
            public IEnumerable<IStatementFactory> GetStatementFactories()
            {
                yield break;
            }
        }
        
        [Fact]
        public void Process_Fails_Without_Tokens()
        {
            Assert.Throws<LexerException>(() => new Configurator()
                .ConfigureInput(new FileInput("TestCases/model.wc"))
                .ConfigureTokens(new DummyTokensProvider())
                .ConfigureStatements(new DummyStatementProvider())
                .Build()
                .Process());
        }
        
        [Fact]
        public void Process_Succeeds_With_All_Tokens_In_Place()
        {
            var statements = new Configurator()
                .ConfigureInput(new FileInput("TestCases/model.wc"))
                .ConfigureTokens(new CalculatorTokensFactoryProvider())
                .ConfigureStatements(new CalculatorStatementFactoriesProvider())
                .Build()
                .Process();
            
            Assert.Equal(1, statements.Count);
        }
    }
}