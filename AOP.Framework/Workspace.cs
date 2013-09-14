using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roslyn.Services;
using Roslyn.Compilers.Common;

namespace AOP.Framework
{
    internal sealed class Workspace
    {
        private readonly IWorkspace _workspace;
 

        internal Workspace(string solutionPath)
        {
            _workspace = Roslyn.Services.Workspace.LoadSolution(solutionPath);
        }

        internal List<T> GetSyntaxTrees<T>() where T : CommonSyntaxTree
        {
            List<T> trees = new List<T>();

            foreach (IProject project in _workspace.CurrentSolution.Projects)
            {
                foreach (IDocument document in project.Documents)
                {
                    if (document.SourceCodeKind == Roslyn.Compilers.SourceCodeKind.Regular)
                    {
                        ISemanticModel model = document.GetSemanticModel();
                        trees.Add((T)model.SyntaxTree);
                    }
                }
            }
            return trees;
        }
    }
}
