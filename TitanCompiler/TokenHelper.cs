namespace TitanCompiler;

public static class TokenHelper
{
    public static readonly Dictionary<string, TokenType> TokenMap = new()
    {
        {"+", TokenType.Plus },
        {"-", TokenType.Minus},
        {"*", TokenType.Asterisk},
        {"/", TokenType.Slash},
        {"\n", TokenType.Newline},
        {"\0", TokenType.Eof},
        {"<", TokenType.Lt},
        {">", TokenType.Gt},
        {"<=", TokenType.Lteq},
        {">=", TokenType.Gteq},
        {"==", TokenType.EqEq},
        {"=", TokenType.Eq},
        {"!=", TokenType.Noteq},
        {"LABEL", TokenType.Label},
        {"GOTO", TokenType.Goto},
        {"PRINT", TokenType.Print},
        {"INPUT", TokenType.Input},
        {"LET", TokenType.Let},
        {"IF", TokenType.If},
        {"THEN", TokenType.Then},
        {"ENDIF", TokenType.Endif},
        {"WHILE", TokenType.While},
        {"REPEAT", TokenType.Repeat},
        {"ENDWHILE", TokenType.Endwhile}
    };
}
