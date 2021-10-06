using Lextatico.Sly.Parser;

namespace Lextatico.Sly.Lexer
{
    public class LexicalError : ParseError
    {
        public LexicalError(int line, int column, string unexpectedSymbol)
        {
            Line = line;
            Column = column;
            UnexpectedSymbol = unexpectedSymbol;
            ErrorType = ErrorType.UnexpectedChar;
        }

        public string UnexpectedSymbol { get; set; }

        public override string ErrorMessage => string.Format("Lexical Error, line {1}, column {2} : Unrecognized symbol '{0}'", UnexpectedSymbol, Line, Column);


        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}