using System;
using System.ComponentModel;
using System.Globalization;

namespace Lextatico.Sly.Lexer
{
    public class Token
    {
        public Token()
        { }

        public Token(string name, string viewName, string resume, string lexeme, TokenType tokenType, IdentifierType? identifierType)
        {
            Name = name;
            ViewName = viewName;
            Resume = resume;
            Lexeme = lexeme;
            TokenType = tokenType;
            IdentifierType = identifierType;
        }

        public string Name { get; set; }

        public string ViewName { get; set; }

        public string Resume { get; set; }

        public string Lexeme { get; set; }

        public TokenType TokenType { get; set; }

        public IdentifierType? IdentifierType { get; set; }

        public override string ToString()
        {
            return TokenType.ToString();
        }
    }

    public enum TokenType
    {
        [Description("Quando nenhum TokenType é definido. Ex: node \"start\"")]
        Default,
        Identifier,
        String,
        Char,
        Integer,
        Float,
        KeyWord,
        SugarToken
    }

    public enum IdentifierType
    {
        AlphaIdentifier,
        AlphaNumIdentifier,
        AlphaNumDashIdentifier
    }
}