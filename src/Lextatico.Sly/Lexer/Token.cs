using System;
using System.ComponentModel;
using System.Globalization;

namespace Lextatico.Sly.Lexer
{
    public class Token
    {
        public Token()
        { }

        public Token(string name, string lexeme, TokenType tokenType, IdentifierType? identifierType)
        {
            Name = name;
            Lexeme = lexeme;
            TokenType = tokenType;
            IdentifierType = identifierType;
        }

        public string Name { get; set; }

        public string Lexeme { get; set; }

        public TokenType TokenType { get; set; }

        public IdentifierType? IdentifierType { get; set; }

        public override string ToString()
        {
            return Enum.GetName(typeof(TokenType), TokenType);
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