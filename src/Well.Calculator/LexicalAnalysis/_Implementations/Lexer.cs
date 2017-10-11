using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Well.Calculator.Exceptions;
using Well.Calculator.Reader;
using Well.Calculator.Tokens;

namespace Well.Calculator.LexicalAnalysis
{
    internal class Lexer : ILexer
    {
        private readonly IEnumerable<ITokenFactory> _tokenFactories;

        public Lexer(ITokenFactoriesProvider factoriesProvider)
        {
            _tokenFactories = factoriesProvider.GetTokenFactories();
        }

        public IEnumerable<IToken> Analyze(IReader reader)
        {
            var currentTokenStringBuilder = new StringBuilder();
            IToken previousToken = null;
            while (reader.Next())
            {
                var currentChar = reader.Peek();
                if (TryCreateToken(currentChar.ToString(), out var currentToken))
                {
                    if (previousToken == null || currentToken.SemanticallyEquals(previousToken))
                    {
                        previousToken = currentToken;
                        currentTokenStringBuilder.Append(currentChar);
                        continue;
                    }

                    if (TryCreateToken(currentTokenStringBuilder.ToString(), out previousToken))
                    {
                        yield return previousToken;
                        currentTokenStringBuilder.Clear();

                        previousToken = currentToken;
                        currentTokenStringBuilder.Append(currentChar);
                    }
                    else
                    {
                        throw new LexerException(currentTokenStringBuilder.ToString());
                    }
                }
                else
                {
                    currentTokenStringBuilder.Append(currentChar);
                }
            }

            if (currentTokenStringBuilder.Length > 0)
            {
                if (TryCreateToken(currentTokenStringBuilder.ToString(), out previousToken))
                {
                    yield return previousToken;
                }
                else
                {
                    throw new LexerException(currentTokenStringBuilder.ToString());
                }
            }
        }

        private bool TryCreateToken(string input, out IToken token)
        {
            foreach (var tokenFactory in _tokenFactories)
            {
                if (tokenFactory.TryCreate(input, out token))
                {
                    return true;
                }
            }

            token = null;
            return false;
        }
    }
}