using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Sly.Lexer.Fsm;

namespace Lextatico.Sly.Lexer
{
    public class FsmLexer<T> : AbstractFsmLexer<T>
        where T : Token
    {
        public override FsmLexerNode<T> AddNode(T value)
        {
            var lexerNode = new FsmLexerNode<T>(value);

            return AddNode(lexerNode);
        }

        public override FsmLexerNode<T> AddNode()
        {
            var node = new FsmLexerNode<T>();

            return AddNode(node);
        }

        private FsmLexerNode<T> AddNode(FsmLexerNode<T> lexerNode)
        {
            lexerNode.Id = Nodes.Count;

            Nodes[lexerNode.Id] = lexerNode;

            return lexerNode;
        }

        public override void AddTransition(FsmLexerTransition transition)
        {
            var transitions = new List<FsmLexerTransition>();

            if (Transitions.ContainsKey(transition.FromNode)) transitions = Transitions[transition.FromNode];

            transitions.Add(transition);

            Transitions[transition.FromNode] = transitions;
        }

        public override FsmLexerNode<T> GetNext(int from, char token)
        {
            var node = Nodes[from];

            return Move(node, token, "".AsMemory());
        }

        public override FsmLexerTransition GetTransition(int nodeId, char token)
        {
            FsmLexerTransition transition = null;

            if (HasState(nodeId))
                if (Transitions.ContainsKey(nodeId))
                {
                    var leavingTransitions = Transitions[nodeId];

                    transition = leavingTransitions.FirstOrDefault(t => t.Match(token));
                }

            return transition;
        }

        public override FsmLexerMatch<T> Run(string source, LexerPosition lexerPosition)
        {
            return Run(new ReadOnlyMemory<char>(source.ToCharArray()), lexerPosition);
        }

        public override FsmLexerMatch<T> Run(ReadOnlyMemory<char> source, LexerPosition lexerPosition)
        {
            // TODO: AQUI REGRA DE VALIDAR O TOKEN
            throw new NotImplementedException();
        }

        private FsmLexerNode<T> Move(FsmLexerNode<T> from, char token, ReadOnlyMemory<char> value)
        {
            if (from != null && Transitions.TryGetValue(from.Id, out var transitions))
            {
                for (var i = 0; i < transitions.Count; ++i)
                {
                    var transition = transitions[i];
                    if (transition.Match(token, value))
                    {
                        return Nodes[transition.ToNode];
                    }
                }
            }

            return null;
        }

        
    }
}