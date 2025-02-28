namespace CeeShardLang;

public enum TokenType
{
    Number,
    Identifier,
    // keywords
    VarDeclaration,
    ConstantDeclaration,
    Equals,
    EndOfStmt,
    EndOfFile
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