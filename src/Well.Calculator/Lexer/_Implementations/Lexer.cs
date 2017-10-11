using System.Collections.Generic;
using System.Text;
using Well.Calculator.Exceptions;
using Well.Calculator.Reader;

namespace Well.Calculator.Lexer
{
    public class Lexer : ILexer
    {
        private readonly ITokenFactory _factory;

        public Lexer(ITokenFactory factory)
        {
            _factory = factory;
        }

        public IEnumerable<IToken> Analyze(IReader reader)
        {
            var currentToken = new StringBuilder();
            while (reader.Next())
            {
                var currentChar = reader.Peek();
                
                
                if (_factory.TryCreate(currentChar.ToString(), out var token))
                {
                    if (currentToken.Length > 0 && _factory.TryCreate(currentToken.ToString(), out var previousToken))
                    {
                        yield return previousToken;
                    }
                    else
                    {
                        throw new LexerException(currentToken.ToString());
                    }

                    yield return token;
                }
                else
                {
                    currentToken.Append(currentChar);
                }
            }

            if (currentToken.Length > 0)
            {
                
            }
        }
    }
}