﻿namespace TitanCompiler;

public class Token
{
    public TokenType Type { get; }
    public string Text { get; }

    public Token(TokenType type, string text)
    {
        Type = type;
        Text = text;
    }
}
