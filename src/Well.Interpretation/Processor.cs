using System.Collections.Generic;
using System.Linq;
using Well.Interpretation.Input;
using Well.Interpretation.Interpreter;
using Well.Interpretation.LexicalAnalysis;
using Well.Interpretation.Statements;
using Well.Interpretation.Tokens;

namespace Well.Interpretation
{
    public interface IProcessor
    {
        ICollection<IStatement> Process();
    }

    internal class Processor : IProcessor
    {
        private readonly IInput _input;
        private readonly ILexer _lexer;
        private readonly ITokensInterpretation _interpretor;

        public Processor(IInput input, ILexer lexer, ITokensInterpretation interpretor)
        {
            _input = input;
            _lexer = lexer;
            _interpretor = interpretor;
        }

        public ICollection<IStatement> Process()
        {
            var reader = _input.Read();
            var tokens = _lexer.Analyze(reader).ToList();
            var statements = _interpretor.Interpret(tokens, out var context).ToList();
            return statements;
        }
    }
}