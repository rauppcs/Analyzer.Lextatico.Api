using System;
using System.Globalization;

namespace Lextatico.Sly.Lexer
{
    public class Token
    {
        public string Name { get; set; }

        public string Lexeme { get; set; }

        public TokenType TokenType { get; set; }

        public ReadOnlyMemory<char> SpanValue { get; set; }

        public LexerPosition Position { get; set; }

        public char StringDelimiter = '"';
        
        public char CharDelimiter ='\'';

        public int PositionInTokenFlow { get; set; }

        public bool IsComment { get; set; }

        public bool Discarded { get; set; } = false;

        public bool IsEOS { get; set; }

        public bool IsIndent { get; set; }

        public bool IsUnIndent { get; set; }

        public int IndentationLevel { get; set; }

        public bool IsEmpty { get; set; }

        public string Value => SpanValue.ToString();

        public string StringWithoutQuotes
        {
            get
            {
                var result = Value;
                if (StringDelimiter != (char)0)
                {
                    if (result.StartsWith(StringDelimiter.ToString())) result = result.Substring(1);
                    if (result.EndsWith(StringDelimiter.ToString())) result = result.Substring(0, result.Length - 1);
                }

                return result;
            }
        }

        public int IntValue => int.Parse(Value);

        public double DoubleValue
        {
            get
            {
                // Try parsing in the current culture
                if (!double.TryParse(Value, NumberStyles.Any, CultureInfo.CurrentCulture,
                        out var result) &&
                    // Then try in US english
                    !double.TryParse(Value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"),
                        out result) &&
                    // Then in neutral language
                    !double.TryParse(Value, NumberStyles.Any, CultureInfo.InvariantCulture,
                        out result))
                {
                    result = 0.0;
                }

                return result;
            }
            set { }
        }

        public char CharValue
        {
            get
            {
                var result = Value;
                if (CharDelimiter != (char)0)
                {
                    if (result.StartsWith(CharDelimiter.ToString()))
                    {
                        result = result.Substring(1);
                    }
                    if (result.EndsWith(CharDelimiter.ToString()))
                    {
                        result = result.Substring(0, result.Length - 1);
                    }
                }
                return result[0];
            }
        }


        public bool End { get; set; }
        public bool IsLineEnding { get; set; }

        public static Token Empty()
        {
            var empty = new Token();

            empty.IsEmpty = true;
            
            return empty;
        }
    }

    public enum TokenType
    {
        Identifier,
        String,
        Integer,
        Float,
        KeyWord,
        SugarToken
    }
}