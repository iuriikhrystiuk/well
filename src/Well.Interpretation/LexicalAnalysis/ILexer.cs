using System.Collections.Generic;
using Well.Interpretation.Reader;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.LexicalAnalysis
{
    internal interface ILexer
    {
        IEnumerable<IToken> Analyze(IReader reader);
    }
}