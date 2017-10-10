using System.Collections.Generic;
using Well.Calculator.Reader;

namespace Well.Calculator.Lexer
{
    public interface ILexer
    {
        IEnumerable<IToken> Analyze(IReader reader);
    }
}