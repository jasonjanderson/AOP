using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOP.Framework
{
    public abstract class PointCut
    {
        internal abstract object GetJoinPoints();
    }
}
