using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Sly.Lexer.Fsm;

namespace Lextatico.Sly.Lexer
{
    public class LextaticoLexer<T> : ILexer<T> where T : Token
    {
        // protected readonly Dictionary<GenericToken, Dictionary<string, IN>> derivedTokens;
        // protected IN doubleDerivedToken;
        // protected char EscapeStringDelimiterChar;

        public LextaticoLexer(IList<T> tokens) : base()
        {
        }

        public FsmLexerBuilder<T> FsmLexerBuilder;
        protected AbstractFsmLexer<T> FsmLexer;

        protected readonly Dictionary<TokenType, Dictionary<string, T>> DerivedTokens;
        protected int StringCounter;
        protected int CharCounter;

        public void AddDefinition(TokenDefinition tokenDefinition)
        {
        }

        public LexerResult<T> Tokenize(string source)
        {
            var memorySource = new ReadOnlyMemory<char>(source.ToCharArray());

            return Tokenize(memorySource);
        }

        public LexerResult<T> Tokenize(ReadOnlyMemory<char> source)
        {
            var position = new LexerPosition();

            var tokens = new List<Token>();

            var fsmMatch = FsmLexer.Run(source, new LexerPosition());

            if (!fsmMatch.IsSuccess && !fsmMatch.IsEOS)
            {
                var result = fsmMatch.Result;
                var error = new LexicalError(result.Position.Line, result.Position.Column, result.CharValue);
                return new LexerResult<T>(error);
            }

            // TODO: AQUI DESENVOLVER MINHA REGRA

            throw new NotImplementedException();
        }

        public LextaticoLexer<T> InitializeLexer(IList<T> tokens)
        {
            var fsmBuilder = new FsmLexerBuilder<T>();

            foreach (var token in tokens)
            {
                AddLexeme(token);
            }

            FsmLexer = fsmBuilder.Lexer;

            return this;
        }

        public virtual T Transcode(FsmLexerMatch<T> match)
        {
            var tok = Activator.CreateInstance<T>();
            var inTok = match.Result;
            tok.IsComment = inTok.IsComment;
            tok.IsEmpty = inTok.IsEmpty;
            tok.SpanValue = inTok.SpanValue;
            tok.Position = inTok.Position;
            tok.Discarded = inTok.Discarded;
            tok.StringDelimiter = match.StringDelimiterChar;
            tok.IsLineEnding = match.IsLineEnding;
            tok.IsEOS = match.IsEOS;
            tok.IsIndent = match.IsIndent;
            tok.IsUnIndent = match.IsUnIndent;
            tok.IndentationLevel = match.IndentationLevel;

            return tok;
        }

        private void AddLexeme(T token)
        {
            // TODO: AQUI REGRA PARA INICIAR TODAS AS TRANSAÇÕES
        }

        private void AddIdentifier()
        {

        }

        private void AddString()
        {

        }

        private void AddInteger()
        {

        }

        private void AddFloat()
        {

        }

        private void AddKeyWord()
        {

        }

        private void AddSugarToken()
        {

        }
    }
}