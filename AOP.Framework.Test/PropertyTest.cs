using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.Compilers.CSharp;

namespace AOP.Framework.Test
{
    [TestClass]
    public class PropertyTest
    {
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
    }
}");
            SyntaxNode newSource = (new FunctionRewriter(new FunctionEvents())).Visit(tree.GetRoot());
            Assert.IsNotNull(newSource);
            
        }
    }
}
