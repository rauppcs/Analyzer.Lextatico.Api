using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Sly.Lexer;

namespace Lextatico.Sly.Parser.Syntax.Grammar
{
    public class Rule<T> where T : Token
    {
        public Rule()
        {
            Clauses = new List<IClause<T>>();
        }

        public bool IsByPassRule { get; set; } = false;

        public bool IsExpressionRule { get; set; }

        // public Affix ExpressionAffix { get; set; }

        public string RuleString { get; set; }

        public string Key
        {
            get
            {
                var key = string.Join("_", Clauses.Select(c => c.ToString()));

                if (Clauses.Count == 1)
                    key += "_";

                return IsExpressionRule ? key.Replace(" | ", "_") : key;
            }
        }

        public List<IClause<T>> Clauses { get; set; }
        public IList<T> PossibleLeadingTokens { get; set; }

        public string NonTerminalName { get; set; }

        // public bool ContainsSubRule
        // {
        //     get
        //     {
        //         if (Clauses != null && Clauses.Any())
        //             foreach (var clause in Clauses)
        //             {
        //                 if (clause is GroupClause<T>) return true;
        //                 if (clause is ManyClause<T> many) return many.Clause is GroupClause<T>;
        //                 if (clause is OptionClause<T> option) return option.Clause is GroupClause<T>;
        //             }

        //         return false;
        //     }
        // }

        // public bool IsSubRule { get; set; }

        public bool MayBeEmpty => Clauses == null
                                  || Clauses.Count == 0
                                  || Clauses.Count == 1 && Clauses[0].MayBeEmpty();


        // public OperationMetaData<T> GetOperation(T token = default(T))
        // {
        //     if (IsExpressionRule)
        //     {
        //         var operation = VisitorMethodsForOperation.ContainsKey(token)
        //             ? VisitorMethodsForOperation[token]
        //             : null;
        //         return operation;
        //     }

        //     return null;
        // }

        // public List<OperationMetaData<T>> GetOperations()
        // {
        //     if (IsExpressionRule)
        //     {
        //         return VisitorMethodsForOperation.Values.ToList();
        //     }

        //     return null;
        // }

        // public MethodInfo GetVisitor(T token = default(T))
        // {
        //     MethodInfo visitor = null;
        //     if (IsExpressionRule)
        //     {
        //         var operation = VisitorMethodsForOperation.ContainsKey(token)
        //             ? VisitorMethodsForOperation[token]
        //             : null;
        //         visitor = operation?.VisitorMethod;
        //     }
        //     else
        //     {
        //         visitor = Visitor;
        //     }

        //     return visitor;
        // }

        // public void SetVisitor(MethodInfo visitor)
        // {
        //     Visitor = visitor;
        // }

        // public void SetVisitor(OperationMetaData<T> operation)
        // {
        //     VisitorMethodsForOperation[operation.OperatorToken] = operation;
        // }
    }
}