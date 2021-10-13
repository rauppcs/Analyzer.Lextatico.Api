using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Sly.Lexer;
using Lextatico.Sly.Parser.Builder;
using Xunit;

namespace Lextatico.Tests.Lextatico.Sly.Parser
{
    public class LextaticoParserBuilderTests
    {
        [Fact]
        public void LextaticoParserBuilder_Build()
        {
            var tokens = new List<Token>
            {
                new Token("Int", "INT", "Qualquer coisa", "int", TokenType.KeyWord),
                new Token("Ponto e vírgula", "SEMICOLON", "Qualquer coisa", ";", TokenType.SugarToken)
            };

            var productionRules = new List<string>
            {
                "program: INT SEMICOLON"
            };

            var lextaticoParserBuilder = new LextaticoParserBuilder<Token>(tokens);

            var result = lextaticoParserBuilder.BuildParser("program", ParserType.LlRecursiveDescent, productionRules);

            Assert.True(result.IsOk);
        }

        [Fact]
        public void LextaticoParserBuilder_Parse()
        {
            var tokens = new List<Token>
            {
                new Token("Int", "INT", "Qualquer coisa", "int", TokenType.KeyWord),
                new Token("Char", "CHAR", "Qualquer coisa", "char", TokenType.KeyWord),
                new Token("Ponto e vírgula", "SEMICOLON", "Qualquer coisa", ";", TokenType.SugarToken)
            };

            var productionRules = new List<string>
            {
                "program: intdeclaration",
                "program: chardeclaration",
                "intdeclaration: INT SEMICOLON",
                "chardeclaration: CHAR SEMICOLON"
            };

            var lextaticoParserBuilder = new LextaticoParserBuilder<Token>(tokens);

            var buildResult = lextaticoParserBuilder.BuildParser("program", ParserType.LlRecursiveDescent, productionRules);

            var parseResult = buildResult.Result.Parse("char int;", "program");

            var message = parseResult.Errors.FirstOrDefault()?.ErrorMessage ?? "";

            Assert.True(parseResult.IsOk);
        }
    }
}