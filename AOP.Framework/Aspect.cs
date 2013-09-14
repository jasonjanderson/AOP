using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Framework
{
    public class Aspect
    {
        public List<IAdvice> Advices { get; set; }

        public List<BasePointCut> PointCuts { get; set; }
    }
}