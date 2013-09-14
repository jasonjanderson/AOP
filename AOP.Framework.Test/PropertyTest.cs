using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.Compilers.CSharp;
using System.Collections.Generic;

namespace AOP.Framework.Test
{
    [TestClass]
    public class PropertyTest
    {
        public class BeforeAdvice : IBeforeMethodAdvice
        {
            public void Implementation(string methodName)
            {
                Console.WriteLine(methodName);
            }
        }

        public class AfterAdvice : IAfterMethodAdvice
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

        [TestMethod]
        public void TestProperty()
        {
            SyntaxTree tree = SyntaxTree.ParseText(
@"using System;
using System.Collections;
using System.Linq;
using System.Text;
using AOP.Framework;

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

        int GetStuff(int stuff1, BasePointCut stuff2, List<string> stuff3)
        {
            return _test;
        }
    }
}");
            MethodNamePointCut beforeCut = new MethodNamePointCut();
            beforeCut.Expression = new System.Text.RegularExpressions.Regex("Get?");

            MethodNamePointCut afterCut = new MethodNamePointCut();
            afterCut.Expression = new System.Text.RegularExpressions.Regex("Main");
            SyntaxNode newSource = (new MethodRewriter(new BeforeAdvice(), beforeCut)).Visit(tree.GetRoot());
            newSource = (new MethodRewriter(new AfterAdvice(), afterCut)).Visit(SyntaxTree.ParseText(newSource.ToFullString()).GetRoot());
            Assert.IsNotNull(newSource);
            
        }
    }
}
