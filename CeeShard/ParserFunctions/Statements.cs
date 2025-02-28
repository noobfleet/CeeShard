namespace CeeShard;

public partial class Parser
{
    private Stmt parseVarDeclaration()
    {
        bool isConst = (advance().Type == TokenType.ConstantDeclaration);
        string identifier = expect(TokenType.Identifier).Value;
        
        VarDeclaration varDecl = new();
        varDecl.Identifier = identifier;
        varDecl.IsConstant = isConst;

        if(at().Type == TokenType.EndOfStmt)
        {
            if(isConst) throw new Exception($"Constant variable {identifier} cannot be declared with null value");
            
            varDecl.Value = null;
            
            return varDecl;
        }

        expect(TokenType.Equals);
        
        varDecl.Value = ParseExpr();
        
        expect(TokenType.EndOfStmt);
        
        return varDecl;
    }
    private Stmt ParseStmt()
    {
        switch(at().Type)
        {
            case TokenType.VarDeclaration: return parseVarDeclaration();
        }

        return ParseExpr();
    }
}