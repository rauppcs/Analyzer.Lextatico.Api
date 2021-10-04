using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Sly.Lexer;
using Xunit;

namespace Lextatico.Tests.Lextatico.Sly.Lexer
{
    public class LextaticoLexerBuilderTests
    {
        [Fact]
        public void LextaticoLexerBuilder_Build()
        {
            var tokens = new List<Token>
            {
                new Token
                {
                    Name = "Int",
                    Lexeme = "int",
                    TokenType = TokenType.KeyWord,
                    SpanValue = new ReadOnlyMemory<char>(new char[] { 'i', 'n', 't' }),
                    Position = new LexerPosition(),
                    PositionInTokenFlow = 0,
                    IsEOS = false,
                    IsEmpty = false,
                    End = true,
                    IsLineEnding = false
                }
            };

            var lexerBuilder = new LextaticoLexerBuilder<Token>(tokens);

            var result = lexerBuilder.Build();

            Assert.True(result.IsOk);
        }
    }
}