using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AParser.src.ast
{
    public enum NodeType
    {
        UNARY, BINARY,
    }

    public class AstNode
    {
        NodeType type;
        Token? token;

        public AstNode(Token token)
        {
            this.token = token;
        }

        public virtual NodeType GetNodeType() { return type; }
    }
}
