using System;
using System.Collections.Generic;
using System.Linq;
using Roslyn.Compilers.CSharp;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOP.Framework
{
    public class MethodNamePointCut : PointCut
    {
        public Regex Expression { get; set; }

        internal override bool Match(SyntaxNode node)
        {
            return false;
        }
    }
}
