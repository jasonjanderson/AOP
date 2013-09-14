using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Framework
{
    public sealed class FunctionRewriter : BaseAOPRewriter
    {
        private readonly FunctionEvents _events;

        public FunctionRewriter(FunctionEvents events)
        {
            this._events = events;
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            return node; //node.Body.Statements.Add(new BlockSyntax();
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var field = Syntax.FieldDeclaration(
                    Syntax.VariableDeclaration(
                        Syntax.PredefinedType(
                            Syntax.Token(
                                SyntaxKind.StringKeyword
                            )
                        )
                    )
                )
                .WithModifiers(Syntax.Token(SyntaxKind.PrivateKeyword))
                .AddDeclarationVariables(Syntax.VariableDeclarator("_newField"));
            node.AddMembers(field).NormalizeWhitespace();
            return node;

        }



    }
}
