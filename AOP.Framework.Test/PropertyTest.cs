using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.Compilers.CSharp;

namespace AOP.Framework.Test
{
    [TestClass]
    public class PropertyTest
    {
        public class BeforeAdvice : IBeforeAdvice
        {
            public void Implementation(string methodName)
            {
                Console.WriteLine(methodName);
            }
        }

        [TestMethod]
        public void TestProperty()
        {
            SyntaxTree tree = SyntaxTree.ParseText(
@"using System;
using System.Collections;
using System.Linq;
using System.Text;
 
namespace HelloWorld
{
    class Program
    {
        private int _test;

        public int Test 
        {
            get;
            set;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello, World!"");
        }

        int GetStuff(int stuff1, string stuff2, List<string> stuff3)
        {
            return _test;
        }
    }
}");
            MethodNamePointCut cut = new MethodNamePointCut();
            cut.Expression = new System.Text.RegularExpressions.Regex("Get?");
            SyntaxNode newSource = (new FunctionRewriter(new BeforeAdvice(), new MethodNamePointCut())).Visit(tree.GetRoot());
            Assert.IsNotNull(newSource);
            
        }
    }
}
