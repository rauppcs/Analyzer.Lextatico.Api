using Lextatico.Sly.Parser;

namespace Lextatico.Sly.Lexer
{
    public class LexicalError : ParseError
    {
        public LexicalError(int line, int column, char unexpectedChar)
        {
            Line = line;
            Column = column;
            UnexpectedChar = unexpectedChar;
            ErrorType = ErrorType.UnexpectedChar;
        }

        public char UnexpectedChar { get; set; }

        public override string ErrorMessage => string.Format("Lexical Error, line {1}, column {2} : Unrecognized symbol '{0}'", UnexpectedChar.ToString(), Line.ToString(), Column.ToString());

        
        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}