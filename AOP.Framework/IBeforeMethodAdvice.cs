using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Framework
{
    public interface IBeforeMethodAdvice : IAdvice
    {
        void Implementation(string methodName, List<ObjectRep> parameters);
    }
}
