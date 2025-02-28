namespace CeeShardLang;

public class Stmt
{
    NodeType Kind;
}

public class Expr
{
    NodeType Kind;
}

/*
 *
 * STATEMENTS
 * 
 */

public class LangProgram : Stmt
{
    NodeType Kind = NodeType.Program;
    Stmt[] Body;
}

public class VarDeclaration : Stmt
{
    NodeType Kind = NodeType.VarDeclaration;
    bool IsConstant;
    string Identifier;
    Expr Value;
}

/*
 *
 * EXPRESSIONS
 * 
*/

public class AssignmentExpr : Expr
{
    NodeType Kind = NodeType.AssignmentExpr;
    Expr Assignee;
    Expr Value;
}

public class BinaryExpr : Expr
{
    NodeType Kind = NodeType.BinaryExpr;
    Expr Left;
    Expr Right;
    string Operator;
}

/*
 *
 * LITERALS
 * 
*/

public class Identifier : Expr
{
    NodeType Kind = NodeType.Identifier;
    string Symbol;
}

public class NumericLiteral : Expr
{
    NodeType Kind = NodeType.NumericLiteral;
    double Value;
}