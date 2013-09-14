using Roslyn.Compilers.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Framework
{
    internal abstract class BaseAOPRewriter
        : SyntaxRewriter
    {
        protected readonly IAdvice Advice;
        protected readonly BasePointCut PointCut;

        internal BaseAOPRewriter(IAdvice advice, BasePointCut pointcut)
        {
            this.Advice = advice;
            this.PointCut = pointcut;
        }


    }
}
