using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lextatico.Sly.Lexer;
using Lextatico.Sly.Lexer.Fsm;

namespace Lextatico.Sly.Parser
{
    public class UnexpectedTokenSyntaxError<T> : ParseError where T : Token
    {
        public UnexpectedTokenSyntaxError(LexerToken<T> unexpectedToken, params T[] expectedTokens)
        {
            ErrorType = unexpectedToken.IsEOS ? ErrorType.UnexpectedEOS : ErrorType.UnexpectedToken;

            UnexpectedToken = unexpectedToken;
            if (expectedTokens != null)
            {
                ExpectedTokens = new List<T>();
                ExpectedTokens.AddRange(expectedTokens);
            }
            else
            {
                ExpectedTokens = null;
            }

        }

        public LexerToken<T> UnexpectedToken { get; set; }

        public List<T> ExpectedTokens { get; set; }

        public override int Line
        {
            get
            {
                var l = UnexpectedToken?.Position?.Line;
                return l.HasValue ? l.Value : 1;
            }
        }

        public override int Column
        {
            get
            {
                var c = UnexpectedToken?.Position?.Column;
                return c.HasValue ? c.Value : 1;
            }
        }

        public override string ErrorMessage
        {
            get
            {
                var expecting = new StringBuilder();

                if (ExpectedTokens != null && ExpectedTokens.Any())
                {
                    for (int i = 0; i < ExpectedTokens.Count; i++)
                    {
                        T t = ExpectedTokens[i];

                        expecting.Append(t);

                        if (i > 0)
                            expecting.Append(", ");
                    }
                }

                string message;

                if (UnexpectedToken.IsEOS)
                {
                    message = "unexpected end of stream";
                    if (ExpectedTokens != null && ExpectedTokens.Any())
                    {
                        message = "unexpected end of stream. Expecting: {0}";
                    }

                    return string.Format(message, expecting.ToString());
                }
                else
                {
                    string value = UnexpectedToken.ToString();

                    message = "unexpected \"{0}\" ({1})";

                    if (ExpectedTokens != null && ExpectedTokens.Any())
                    {
                        message = "unexpected '{0}'. Expecting {1}";

                        return string.Format(message, value, expecting.ToString());
                    }

                    return string.Format(message, value, UnexpectedToken.Result?.ToString() ?? "");
                }
            }
        }

        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}