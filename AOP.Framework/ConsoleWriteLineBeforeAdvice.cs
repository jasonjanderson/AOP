using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP.Framework
{
    public class ConsoleWriteLineBeforeAdvice : IAdvice
    {
        public void Implementation(string methodName, List<ObjectRep> parameters)
        {
            Console.WriteLine(methodName + ":");
            foreach (var param in parameters)
            {
                Console.WriteLine(" " + param.Name + ": " + param.Value.ToString());
            }
        }
    }
}
