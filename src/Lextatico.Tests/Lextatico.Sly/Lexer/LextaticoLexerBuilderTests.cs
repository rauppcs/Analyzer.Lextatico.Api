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
                    Name = "Texto",
                    Lexeme = "string",
                    TokenType = TokenType.String,
                },
                new Token
                {
                    Name = "Caractere",
                    Lexeme = "char",
                    TokenType = TokenType.Char,
                },
                new Token
                {
                    Name = "Int",
                    Lexeme = "int",
                    TokenType = TokenType.KeyWord,
                },
                new Token
                {
                    Name = "Char",
                    Lexeme = "char",
                    TokenType = TokenType.KeyWord,
                },
                new Token
                {
                    Name = "Inteiro",
                    Lexeme = "",
                    TokenType = TokenType.Integer,
                },

                new Token
                {
                    Name = "Real",
                    Lexeme = "",
                    TokenType = TokenType.Float,
                },
                new Token
                {
                    Name = "Identificador",
                    Lexeme = "id",
                    TokenType = TokenType.Identifier,
                    IdentifierType = IdentifierType.AlphaNumDashIdentifier
                },
                new Token
                {
                    Name = "Ponto e vírgula",
                    Lexeme = ";",
                    TokenType = TokenType.SugarToken,
                },
                new Token
                {
                    Name = "Dois pontos",
                    Lexeme = ":",
                    TokenType = TokenType.SugarToken,
                },
                new Token
                {
                    Name = "Atribuição",
                    Lexeme = "=",
                    TokenType = TokenType.SugarToken
                },
                new Token
                {
                    Name = "Igual",
                    Lexeme = "==",
                    TokenType = TokenType.SugarToken,
                }
            };

            var lexerBuilder = new LextaticoLexerBuilder<Token>(tokens);

            var result = lexerBuilder.Build();

            Assert.True(result.IsOk);
        }

        [Fact]
        public void LextaticoLexerBuilder_Tokenize()
        {
            var tokens = new List<Token>
            {
                new Token
                {
                    Name = "Int",
                    Lexeme = "int",
                    TokenType = TokenType.KeyWord,
                },
                new Token
                {
                    Name = "Identificador",
                    Lexeme = "id",
                    TokenType = TokenType.Identifier,
                    IdentifierType = IdentifierType.AlphaNumDashIdentifier
                },
                new Token
                {
                    Name = "Número inteiro",
                    Lexeme = "",
                    TokenType = TokenType.Integer
                },
                new Token
                {
                    Name = "Número real",
                    Lexeme = "",
                    TokenType = TokenType.Float
                },
                new Token
                {
                    Name = "Atribuição",
                    Lexeme = "=",
                    TokenType = TokenType.SugarToken
                },
                new Token
                {
                    Name = "Ponto e vírgula",
                    Lexeme = ";",
                    TokenType = TokenType.SugarToken,
                }
            };

            var lexerBuilder = new LextaticoLexerBuilder<Token>(tokens);

            var result = lexerBuilder.Build();

            var tokenResult = result.Result.Tokenize("int abc = 125.12;");
        }
    }
}