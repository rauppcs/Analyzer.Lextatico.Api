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
            _tokens = tokens;
        }

        private readonly IList<T> _tokens;

        public FsmLexerBuilder<T> FsmLexerBuilder;

        protected AbstractFsmLexer<T> FsmLexer;

        protected readonly Dictionary<TokenType, Dictionary<string, T>> DerivedTokens;

        protected int StringCounter;

        protected int CharCounter;

        public void AddDefinition(TokenDefinition tokenDefinition) { }

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

        public LextaticoLexer<T> InitializeLexer()
        {
            var fsmLexerBuilder = new FsmLexerBuilder<T>();

            foreach (var token in _tokens)
            {
                AddLexeme(fsmLexerBuilder, token);
            }

            FsmLexer = fsmLexerBuilder.Lexer;

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

        private void AddLexeme(FsmLexerBuilder<T> fsmLexerBuilder, T token)
        {
            // TODO: AQUI REGRA PARA INICIAR TODAS AS TRANSAÇÕES
        }

        private void AddIdentifier(FsmLexerBuilder<T> fsmLexerBuilder, T token)
        {
            // TODO: AQUI REGRA PARA TRANSIÇÕES DE IDENTIFICADORES
        }

        private void AddString(FsmLexerBuilder<T> fsmLexerBuilder, T token)
        {

        }

        private void AddChar(FsmLexerBuilder<T> fsmLexerBuilder, T token)
        {

        }

        private void AddInteger(FsmLexerBuilder<T> fsmLexerBuilder, T token)
        {

        }

        private void AddFloat(FsmLexerBuilder<T> fsmLexerBuilder, T token)
        {

        }

        private void AddKeyWord(FsmLexerBuilder<T> fsmLexerBuilder, T token)
        {

        }

        private void AddSugarToken(FsmLexerBuilder<T> fsmLexerBuilder, T token)
        {

        }
    }
}