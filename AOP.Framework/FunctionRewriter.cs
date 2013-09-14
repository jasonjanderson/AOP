using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AOP.Framework
{
    public sealed class FunctionRewriter : SyntaxRewriter
    {
        private readonly IAdvice _advice;
        private readonly BasePointCut _pointCut;

        public FunctionRewriter(IAdvice advice, BasePointCut pointCut)
        {
            this._advice = advice;
            this._pointCut = pointCut;
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (_pointCut.Match(node))
            {
                var adviceType = _advice.GetType();
                var funcCall = string.Format("(new {0}.{1}()).Implemenation(\"{2}\");", adviceType.Namespace, adviceType.Name, node.Identifier.ValueText);
                var statements = new List<StatementSyntax>();
                statements.Add(Syntax.ParseStatement(funcCall));
                statements.AddRange(node.Body.Statements);
                return node.WithBody(Syntax.Block(statements).NormalizeWhitespace());
            }
            return node;
        }




    }
}
