using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AParser.src.ast
{
    public class UnaryNode : AstNode
    {
        public readonly NodeType type = NodeType.UNARY;
        public Token? Operator { get; }
        public AstNode? Expression { get; }

        public UnaryNode(Token op, AstNode expr) : base(op)
        {
            this.Expression = expr;
        }
    }

}
