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
            var field = SyntaxTree.ParseText("private FunctionEvents _;");
            return node.AddMembers(field.GetRoot().Members[0]);
            //return node.WithMembers(newmembers);

        }



    }
}
