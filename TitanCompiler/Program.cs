namespace TitanCompiler;
class Program
{
    private static void Main(string[] args)
    {
        var text = "IF+-123 foo*THEN/";
        var lexer = new Lexer(text);
        var token = lexer.GetToken();
        while (token.Type != TokenType.Eof)
        {
            Console.WriteLine($"{token.Type}: {token.Text}");
            token = lexer.GetToken();
        }
    }
}
