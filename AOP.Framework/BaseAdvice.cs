using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOP.Framework
{
    public abstract class BaseAdvice
    {
        private string _path;

        public string Path { get { return _path; } }

        public BaseAdvice(string path)
        {
            _path = path;
        }
    }
}
