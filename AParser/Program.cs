using AParser.src;

namespace AParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lexer lexer = new Lexer("source.txt");

            Parser parser = new Parser(lexer);
            
        }
    }
}
