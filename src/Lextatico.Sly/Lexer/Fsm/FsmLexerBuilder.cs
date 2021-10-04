using System;
using System.Collections.Generic;
using Lextatico.Sly.Lexer.Fsm.TransitionCheck;
using Lextatico.Sly.Result;

namespace Lextatico.Sly.Lexer
{
    public class FsmLexerBuilder<T> : IFsmLexerBuilder<T>
        where T : Token
    {
        public FsmLexerBuilder()
        {
            Lexer = new FsmLexer<T>();
            CurrentState = 0;
            _marks = new Dictionary<string, int>();
            Lexer.AddNode();
            Lexer.GetNode(0).IsStart = true;
        }

        private readonly Dictionary<string, int> _marks;
        private int CurrentState { get; set; }
        private readonly IList<Token> _tokens;
        public AbstractFsmLexer<T> Lexer { get; }

        public FsmLexerBuilder(IList<Token> tokens)
        {
            _tokens = tokens;
        }

        public BuildResult<AbstractFsmLexer<T>> BuildLexer()
        {
            throw new NotImplementedException();
        }

        public FsmLexerBuilder<T> GoTo(int state)
        {
            if (Lexer.HasState(state))
                CurrentState = state;
            else
                throw new ArgumentException($"state {state} does not exist in lexer FSM");
            return this;
        }

        public FsmLexerBuilder<T> GoTo(string mark)
        {
            if (_marks.ContainsKey(mark))
                GoTo(_marks[mark]);
            else
                throw new ArgumentException($"mark {mark} does not exist in current builder");
            return this;
        }

        public FsmLexerBuilder<T> Mark(string mark)
        {
            _marks[mark] = CurrentState;

            Lexer.GetNode(CurrentState).Mark = mark;

            return this;
        }

        public FsmLexerNode<T> GetNode(int nodeId) => Lexer.GetNode(nodeId);

        public FsmLexerNode<T> GetNode(string mark) => _marks.ContainsKey(mark) ? GetNode(_marks[mark]) : null;

        public FsmLexerBuilder<T> End(T nodeValue, bool isLineEnding = false)
        {
            if (Lexer.HasState(CurrentState))
            {
                var node = Lexer.GetNode(CurrentState);

                node.IsEnd = true;

                node.Value = nodeValue;

                node.IsLineEnding = isLineEnding;
            }

            return this;
        }

        public FsmLexerBuilder<T> SafeTransition(char input)
        {
            var transition = Lexer.GetTransition(CurrentState, input);

            if (transition != null)
                CurrentState = transition.ToNode;
            else
                return TransitionTo(input, Lexer.NewNodeId);

            return this;
        }

        public FsmLexerBuilder<T> Transition(char input)
        {
            var next = Lexer.GetNext(CurrentState, input);

            if (next == null)
            {
                return TransitionTo(input, Lexer.NewNodeId);
            }

            CurrentState = next.Id;

            return this;
        }

        public FsmLexerBuilder<T> Transition(char[] inputs) => TransitionTo(inputs, Lexer.NewNodeId);

        public FsmLexerBuilder<T> ConstantTransition(string constant)
        {
            var c = constant[0];
            SafeTransition(c);
            for (var i = 1; i < constant.Length; i++)
            {
                c = constant[i];
                SafeTransition(c);
            }

            return this;
        }

        public FsmLexerBuilder<T> RangeTransition(char start, char end) => RangeTransitionTo(start, end, Lexer.NewNodeId);

        public FsmLexerBuilder<T> AnyTransition() => AnyTransitionTo(Lexer.NewNodeId);

        public FsmLexerBuilder<T> TransitionTo(char input, int toNode)
        {
            var checker = new TransitionSingle(input);

            if (!Lexer.HasState(toNode)) Lexer.AddNode();

            var transition = new FsmLexerTransition(checker, CurrentState, toNode);

            Lexer.AddTransition(transition);

            CurrentState = toNode;

            return this;
        }

        public FsmLexerBuilder<T> TransitionTo(char[] inputs, int toNode)
        {
            var checker = new TransitionMany(inputs);

            if (!Lexer.HasState(toNode)) Lexer.AddNode();

            var transition = new FsmLexerTransition(checker, CurrentState, toNode);

            Lexer.AddTransition(transition);

            CurrentState = toNode;

            return this;
        }

        public FsmLexerBuilder<T> RangeTransitionTo(char start, char end, int toNode)
        {
            var checker = new TransitionRange(start, end);

            if (!Lexer.HasState(toNode)) Lexer.AddNode();

            var transition = new FsmLexerTransition(checker, CurrentState, toNode);

            Lexer.AddTransition(transition);

            CurrentState = toNode;

            return this;
        }

        public FsmLexerBuilder<T> AnyTransitionTo(int toNode)
        {
            var checker = new TransitionAny();

            if (!Lexer.HasState(toNode)) Lexer.AddNode();

            var transition = new FsmLexerTransition(checker, CurrentState, toNode);

            Lexer.AddTransition(transition);

            CurrentState = toNode;

            return this;
        }

        public FsmLexerBuilder<T> TransitionTo(char input, string toNodeMark)
        {
            if (_marks.TryGetValue(toNodeMark, out var toNode))
                return TransitionTo(input, toNode);

            throw new ArgumentOutOfRangeException(nameof(toNodeMark));
        }

        public FsmLexerBuilder<T> TransitionTo(char[] inputs, string toNodeMark)
        {
            if (_marks.TryGetValue(toNodeMark, out var toNode))
                return TransitionTo(inputs, toNode);

            throw new ArgumentOutOfRangeException(nameof(toNodeMark));
        }

        public FsmLexerBuilder<T> RangeTransitionTo(char start, char end, string toNodeMark)
        {
            if (_marks.TryGetValue(toNodeMark, out var toNode))
                return RangeTransitionTo(start, end, toNode);

            throw new ArgumentOutOfRangeException(nameof(toNodeMark));
        }

        public FsmLexerBuilder<T> AnyTransitionTo(string toNodeMark)
        {
            if (_marks.TryGetValue(toNodeMark, out var toNode))
                return AnyTransitionTo(toNode);

            throw new ArgumentOutOfRangeException(nameof(toNodeMark));
        }
    }
}