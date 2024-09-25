using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AParser.src
{
    public class SourceFileReader
    {

        private void ReadSourceFile(string filename, ref string? stream)
        {
            if (File.Exists(filename)) 
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    StringBuilder builder = new StringBuilder();
                    
                    builder.Append(reader.ReadToEnd());
                    stream = builder.ToString();
                    builder.Clear();
                }
               
            }
            else { throw new FileNotFoundException($"{filename} does not exist in the filesystem."); }
        }

        public string GetSourceCode(string filename)
        {
            string? source = null;

            ReadSourceFile(filename, ref source);

            return source != null ? source.ToString() : "source code not found";
        }

    }
    public class Lexer
    {
        private int indexAt = 0;
        private int line = 1;
        private string source;
        private List<Token> tokens;

        public Lexer(string filename)
        {
            SourceFileReader reader = new SourceFileReader();
            this.source = reader.GetSourceCode(filename);
            tokens = new List<Token>();
        }

        public int Line { get { return line; } }
        public string Source { get { return source; } }
        private bool IsEof { get { return source.ElementAt(indexAt) == '\0'; } }
        private char CurrentChar { get { return source.ElementAt(indexAt); } }
        private void Advance() { indexAt++; }
        private char PeekChar(int offset) 
        {
            if (indexAt + offset < source.Length) { return source[indexAt + offset]; }
            return source[indexAt]; 
        }
        private bool IsOperator()
        {
            if (IsEof) { throw new Exception($"Unexpected eof at Line:{Line}"); }

            return true ? this.Source.ElementAt(indexAt) == '+' ||
                this.Source.ElementAt(indexAt) == '-' || this.source.ElementAt(indexAt) == '*' ||
                this.source.ElementAt(indexAt) == '/' || this.source.ElementAt(indexAt) == '%'
                : false;
        }
        private Token GetNextToken()
        {
            if (IsEof) { return new Token(TokenType.T_ERROR, "Unexpected eof"); }

            if (char.IsNumber(CurrentChar)) { return GetNumberToken(); }
            if (IsOperator()) { return GetOperatorToken(); }

            return new Token(TokenType.T_ERROR, "unknown");
        }
        private Token GetNumberToken()
        {

            return new Token(TokenType.T_NUMBER, null);
        }
        private Token GetOperatorToken()
        {
            return new Token(TokenType.T_OPERATOR, char.ToString(CurrentChar));
        }
        public void Tokenize()
        {
            while (!IsEof)
            {
                tokens.Add(GetNextToken());
                Advance();
            }
            tokens.Add(new Token(TokenType.T_EOF, null));
        }
        public List<Token> GetTokens() { return tokens; }
    }
}
