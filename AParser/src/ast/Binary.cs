using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AParser.src.ast
{
    public class BinaryNode : AstNode
    {
        public readonly NodeType type = NodeType.BINARY;
        public Token? Operator { get; }
        public AstNode? Left { get; }
        public AstNode? Right { get; }

        public BinaryNode(Token op, AstNode leftExp, AstNode rightExp) : base(op)
        {
            this.Left = leftExp;
            this.Right = rightExp;
        }
    }
}
