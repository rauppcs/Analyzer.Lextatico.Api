using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lextatico.Sly.Lexer.Fsm
{
    public class FsmLexerMatch<T> 
        // where T : Token
    {
        public Dictionary<string, object> Properties { get; }

        public bool IsString { get; set; }
        
        public bool IsSuccess { get; set; }

        public bool IsEOS { get; }
        
        public T Result { get; set; }

        public int NodeId { get; }

        public LexerPosition NewPosition { get; set; }
        
        public bool IsLineEnding { get; set; }
        
        
        public FsmLexerMatch(bool success)
        {
            IsSuccess = success;
            IsEOS = !success;
        }

        protected FsmLexerMatch()
        {
            Properties = new Dictionary<string, object>();
        }
        

        public FsmLexerMatch(bool success, T result, int nodeId, LexerPosition newPosition, bool isLineEnding)
        {
            Properties = new Dictionary<string, object>();
            IsSuccess = success;
            NodeId = nodeId;
            IsEOS = false;
            Result = result;
            NewPosition = newPosition;
            IsLineEnding = isLineEnding;
        }
    }
}