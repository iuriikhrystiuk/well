using System.Collections.Generic;
using Well.Calculator.Reader;
using Well.Calculator.Tokens;

namespace Well.Calculator.LexicalAnalysis
{
    internal interface ILexer
    {
        IEnumerable<IToken> Analyze(IReader reader);
    }
}