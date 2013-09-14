using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Framework
{
    public interface IBeforeAdvice
    {
        void Implementation(string methodName);
    }
}
