namespace CeeShardLang;

public enum TokenType
{
    Number,
    Identifier,
    // keywords
    VarDeclaration,
    Equals,
    EndOfStmt,
}

public enum NodeType
{
    // Statements (no return value)
    Program,
    VarDeclaration,
    // Expressions (generally has a return value)
    AssignmentExpr,
    BinaryExpr,
    // Literals
    NumericLiteral,
    Identifier,
}