using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Framework
{
    internal sealed class PropertyOnChangeRewriter : SyntaxRewriter
    {
        private readonly SemanticModel _semanticModel;

        internal PropertyOnChangeRewriter(SemanticModel model)
        {
            this._semanticModel = model;
        }

        public override SyntaxNode VisitPropertyDeclaration(PropertyDeclarationSyntax node)
        {
            if (node.AccessorList.Accessors.Any(SyntaxKind.SetAccessorDeclaration))
            {

            }

        }



    }
}
