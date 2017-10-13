using System.Collections.Generic;
using System.Text;
using Well.Interpretation.Exceptions;
using Well.Interpretation.Reader;
using Well.Interpretation.Tokens;

namespace Well.Interpretation.LexicalAnalysis._Implementations
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