namespace TitanCompiler;

public class Lexer
{
    private readonly string _input;
    private int _currentPosition;
    
    public Lexer(string input)
    {
        _input = input + '\n';
        _currentPosition = 0;
    }

    private void NextChar()
    {
        _currentPosition++;
    }

    private char Peek()
    {
        return _currentPosition >= _input.Length ? '\0' : _input[_currentPosition];
    }

    private char LookAhead()
    {
        return _currentPosition + 1 >= _input.Length ? '\0' : _input[_currentPosition + 1];
    }

    private static void Abort(string message)
    {
        throw new Exception("Error: " + message);
    }

    private void SkipWhitespace()
    {
        var cur = Peek();
        while (cur is ' ' or '\t' or '\r')
        {
            NextChar();
            cur = Peek();
        }
    }

    private void SkipComments()
    {
        while (Peek() != '\n')
        {
            NextChar();
        }
    }

    public Token GetToken()
    {
        // Check for end of file.
        if (Peek() == '\0')
        {
            return new Token(TokenType.Eof, "");
        }
        
        // if whitespace, then skip
        if (Peek() is ' ' or '\t' or '\r' )
            SkipWhitespace();
        // if # then skip rest of line as this is a comment
        if (Peek() == '#')
            SkipComments();
        

        var text = Peek().ToString();
        // Check for = or ==
        if (Peek() == '=' && LookAhead() == '=')
        {
            text = "==";
        }
        // Check for > or >=
        if (Peek() == '>' && LookAhead() == '=')
        {
            text = ">=";
        }
        // Check for < or <=
        if (Peek() == '<' && LookAhead() == '=')
        {
            text = "<=";
        }
        // Check for !=
        if (Peek() == '!' && LookAhead() == '=')
        {
            text = "!=";
        }
        // Check for a string (Between Quotations)
        if (Peek() == '\"')
        {
            NextChar();
            var start = _currentPosition;
            while (Peek() != '\"')
            {
                if (Peek() is '\r' or '\n' or '\t' or '\\' or '%')
                {
                    Abort("Illegal character in string.");
                }
                NextChar();
                if (Peek() == '\0') Abort("Reached end of file without matching quotation.");
            }
            text = _input.Substring(start, _currentPosition - start);
            NextChar();
            return new Token(TokenType.String, text);
        }
        // Check for a Number
        if (char.IsDigit(Peek()))
        {
            var start = _currentPosition;
            while (char.IsDigit(Peek()))
            {
                NextChar();
            }
            // We have a decimal, make sure there is at least one number after the decimal place
            if (Peek() == '.')
            {
                if (!char.IsDigit(LookAhead())) Abort("Illegal character in number.");
                NextChar();
                while (char.IsDigit(Peek()))
                {
                    NextChar();
                }
            }
            text = _input.Substring(start, _currentPosition - start);
            return new Token(TokenType.Number, text);
        }
        
        // Check for Identifier.
        if (char.IsLetter(Peek()))
        {
            var start = _currentPosition;
            while (char.IsLetterOrDigit(Peek()))
            {
                NextChar();
            }

            text = _input.Substring(start, _currentPosition - start);
            return TokenHelper.TokenMap.TryGetValue(text, out var tp) ? new Token(tp, text) : new Token(TokenType.Ident, text);
        }
        
        if (!TokenHelper.TokenMap.TryGetValue(text, out var type))
            type = TokenType.Unknown;

        NextChar();
        return new Token(type, text);
    }
}
