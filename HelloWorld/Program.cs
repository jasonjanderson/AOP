using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
     class Program
    {
        public int Test
        {
            get;
            set;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            GetStuff(1, "NumberTwo", new List<string>() { "0", "a", "0a", "three", "quattro", "The fifth element" });
            System.Threading.Thread.Sleep(10000);
        }

        static int GetStuff(int stuff1, string stuff2, List<string> stuff3)
{
    (new AOP.Framework.ConsoleWriteLineBeforeAdvice()).Implementation("GetStuff", new List<AOP.Framework.ObjectRep>()
    {
    new AOP.Framework.ObjectRep("stuff1", stuff1), new AOP.Framework.ObjectRep("stuff2", stuff2), new AOP.Framework.ObjectRep("stuff3", stuff3)}

    );
    return 1;
}    }
}


/*
 class Program
    {
        public int Test
        {
            get;
            set;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
                        GetStuff(1, "NumberTwo", new List<string>() { "0", "a", "0a", "three", "quattro", "The fifth element" });

        }

        static int GetStuff(int stuff1, string stuff2, List<string> stuff3)
        {
            return 1;
        }
    }
  */
