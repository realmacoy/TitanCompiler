namespace TitanCompiler;

public enum TokenType
{
    Eof = -1,
    Newline = 0,
    Number = 1,
    Ident = 2,
    String = 3,
// Keywords.
    Label = 101,
    Goto = 102,
    Print = 103,
    Input = 104,
    Let = 105,
    If = 106,
    Then = 107,
    Endif = 108,
    While = 109,
    Repeat = 110,
    Endwhile = 111,
// Operators.
    Eq = 201,  
    Plus = 202,
    Minus = 203,
    Asterisk = 204,
    Slash = 205,
    EqEq = 206,
    Noteq = 207,
    Lt = 208,
    Lteq = 209,
    Gt = 210,
    Gteq = 211,
// Unknown
    Unknown = 999
}
