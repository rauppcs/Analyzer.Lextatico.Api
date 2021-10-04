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
            FsmLexerBuilder = new FsmLexerBuilder<T>();

            FsmLexerBuilder.Mark("start");

            var identifier = _tokens.FirstOrDefault(t => t.TokenType == TokenType.Identifier);

            if (_tokens.Any(a => a.TokenType == TokenType.Identifier || a.TokenType == TokenType.KeyWord))
            {
                AddIdentifier(FsmLexerBuilder, identifier, identifier?.IdentifierType ?? IdentifierType.AlphaIdentifier);
            }

            foreach (var token in _tokens)
            {
                AddLexeme(FsmLexerBuilder, token);
            }

            FsmLexer = FsmLexerBuilder.Lexer;

            return this;
        }

        public virtual T Transcode(FsmLexerMatch<T> match)
        {
            var tok = Activator.CreateInstance<T>();
            var inTok = match.Result;
            // tok.IsComment = inTok.IsComment;
            tok.IsEmpty = inTok.IsEmpty;
            tok.SpanValue = inTok.SpanValue;
            tok.Position = inTok.Position;
            tok.IsLineEnding = match.IsLineEnding;
            tok.IsEOS = match.IsEOS;

            return tok;
        }

        private void AddLexeme(FsmLexerBuilder<T> fsmLexerBuilder, T token)
        {
            // TODO: AQUI REGRA PARA INICIAR TODAS AS TRANSAÇÕES
        }

        private void AddIdentifier(IFsmLexerBuilder<T> fsmLexerBuilder, T token, IdentifierType identifierType)
        {
            var nameIdentifier = Enum.GetName(typeof(TokenType), TokenType.Identifier);

            fsmLexerBuilder
                    .GoTo("start")
                    .RangeTransition('a', 'z')
                    .Mark(nameIdentifier)
                    .GoTo("start")
                    .RangeTransitionTo('A', 'Z', nameIdentifier)
                    .RangeTransitionTo('a', 'z', nameIdentifier)
                    .RangeTransitionTo('A', 'Z', nameIdentifier)
                    .End(token);

            if (identifierType == IdentifierType.AlphaNumIdentifier || identifierType == IdentifierType.AlphaNumDashIdentifier)
                {
                    fsmLexerBuilder
                        .GoTo(nameIdentifier)
                        .RangeTransitionTo('0', '9', nameIdentifier);
                }
            
                if (identifierType == IdentifierType.AlphaNumDashIdentifier)
                {
                    fsmLexerBuilder
                        .GoTo("start")
                        .TransitionTo('_', nameIdentifier)
                        .TransitionTo('_', nameIdentifier)
                        .TransitionTo('-', nameIdentifier);
                }
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