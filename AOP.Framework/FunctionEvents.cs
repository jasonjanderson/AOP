using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Framework
{
    public delegate void FunctionEvent(object sender, EventArgs e);

    public sealed class FunctionEvents
    {
        public event FunctionEvent Before;
        public event FunctionEvent After;

        public FunctionEvents()
        {

        }
    }
}
