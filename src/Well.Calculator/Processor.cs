using System.Collections.Generic;
using System.Linq;
using Well.Calculator.Input;
using Well.Calculator.LexicalAnalysis;
using Well.Calculator.Tokens;

namespace Well.Calculator
{
    public interface IProcessor
    {
        ICollection<IToken> Process();
    }

    internal class Processor : IProcessor
    {
        private readonly IInput _input;
        private readonly ILexer _lexer; 

        public Processor(IInput input, ILexer lexer)
        {
            _input = input;
            _lexer = lexer;
        }

        public ICollection<IToken> Process()
        {
            var reader = _input.Read();
            return _lexer.Analyze(reader).ToList();
        }
    }
}