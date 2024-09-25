using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AParser.src
{
    public enum TokenType
    {
        T_EOF, K_VAR, T_STRING, T_NUMBER, T_IDENTIFIER, T_ERROR, T_OPERATOR, T_LPAREN, T_RPAREN, T_EQ,
        T_GT, T_LE, T_PLUS, T_MINUS, T_MUL, T_DIV, T_MOD, 
    }
    public class Token
    {
        public TokenType TType {  get; }
        public string? Value { get; }

        public Token(TokenType tType, string? value)
        {
            TType = tType;
            Value = value;
        }
        public override string ToString() { return $"TokenType: {TType}, Value: {Value}"; }

    }
}
