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
        private readonly IBeforeAdvice _advice;

        public FunctionRewriter(IBeforeAdvice advice)
        {
            this._advice = advice;
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            
            return node; //node.Body.Statements.Add(new BlockSyntax();
        }

        //public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        //{
        //    var field = SyntaxTree.ParseText("private FunctionEvents _events;");
        //    return node.AddMembers(field.GetRoot().Members[0]);
        //    //return node.WithMembers(newmembers);

        //}



    }
}
