﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.Compilers.CSharp;

namespace AOP.Framework.Test
{
    [TestClass]
    public class PropertyTest
    {
        public class BeforeAdvice : BaseBeforeAdvice
        {

            public override void Implementation(string methodName)
            {
                Console.WriteLine(methodName);
            }
            public BeforeAdvice(string path) : base(path)
            {

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
            SyntaxNode newSource = (new FunctionRewriter(new BeforeAdvice(@"C:\Users\nectro\Documents\GitHub\AOP\AOP.Framework.Test\PropertyTest.cs"))).Visit(tree.GetRoot());
            Assert.IsNotNull(newSource);
            
        }
    }
}
