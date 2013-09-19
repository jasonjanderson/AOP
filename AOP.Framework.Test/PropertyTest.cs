using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roslyn.Compilers.CSharp;
using System.Collections.Generic;
using Roslyn.Compilers;
using System.IO;
using System.Linq;
using System.Reflection;
using AOP.Framework;

namespace AOP.Framework.Test
{
    [TestClass]
    public class PropertyTest
    {
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
            string filePath = @"C:\Users\odiernod\Documents\GitHub\AOP\HelloWorld\Program.cs";
            SyntaxTree tree = SyntaxTree.ParseText(File.ReadAllText(filePath));
            MethodNamePointCut cut = new MethodNamePointCut();
            cut.Expression = new System.Text.RegularExpressions.Regex("Get?");
            SyntaxNode newSource = (new MethodRewriter(new ConsoleWriteLineBeforeAdvice(), cut)).Visit(tree.GetRoot());
            Assert.IsNotNull(newSource);
            File.WriteAllText(filePath, newSource.ToFullString());
        }

//        private void compileAndRun(SyntaxNode newSource)
//        {
//            var syntaxTree = SyntaxTree.ParseText(newSource.ToFullString());
//            string dllPath = Path.Combine(Directory.GetCurrentDirectory(), "runStuff.exe");
//>>>>>>> Got Demo working

            
//            var compilation = Compilation.Create("injectedProgram.exe", 
//                syntaxTrees: new[] { syntaxTree },
//                references: new[] {
//                    new MetadataFileReference(typeof(object).Assembly.Location),
//                    new MetadataFileReference(typeof(Enumerable).Assembly.Location),
//                },
//                options: new CompilationOptions(OutputKind.ConsoleApplication)
//            );
            

//            EmitResult result;


//            result = compilation.Emit(dllPath);

//            //if (true)//result.Success)
//            //{
//            //    //assembly = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), @"Greeter.dll"));
//            //    Assembly assembly = Assembly.LoadFrom(dllPath);

//            //    Type type = assembly.GetType("HelloWorld.Program");
//            //    var obj = Activator.CreateInstance(type);

//            //    type.InvokeMember("Main",
//            //        BindingFlags.Default | BindingFlags.InvokeMethod,
//            //        null,
//            //        obj,
//            //        null);
//            //}
//        }
    }
}
