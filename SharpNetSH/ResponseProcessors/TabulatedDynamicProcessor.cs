using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Ignite.SharpNetSH
{
	internal class TabulatedDynamicProcessor : IResponseProcessor
	{
		StandardResponse IResponseProcessor.ProcessResponse(IEnumerable<string> responseLines, int exitCode, String splitRegEx = null)
		{
			var lines = responseLines.ToList();
			var standardResponse = new StandardResponse();
			((IResponseProcessor)standardResponse).ProcessResponse(lines, exitCode);

			if (exitCode != 0) return standardResponse;

			var regex = new Regex(@"[ ]{4}");
			var tabulatedLines = lines.ToList().Select(x =>
			{
				while (Regex.IsMatch(x, @"^\t*([ ]{4})+")) //Ensures we are still working on a tab at the beginning of the line
					x = regex.Replace(x, "\t", 1);
				return x;
			}).ToList(); //Convert the beginning spaces to tabs

			var root = new Tree();
			RecursivelyProcessToTree(tabulatedLines.Skip(3).GetEnumerator(), root, splitRegEx);
			standardResponse.ResponseObject = RecursivelyFlattenToDynamic(root);
			return standardResponse;
		}

		void RecursivelyProcessToTree(IEnumerator<String> lineEnumerator, Tree parent, String splitRegEx)
		{
			//We are in the scope of the owning tree here
			while (lineEnumerator.MoveNext())
			{
				var line = lineEnumerator.Current;
				if (String.IsNullOrWhiteSpace(line))
					continue;

				var level = line.Length - line.TrimStart('\t').Length;
				var tree = new Tree(line.Trim(), level, splitRegEx) { Parent = parent };

				if (parent.TreeLevel == level - 1) // If the new tree is a child of this tree, add it to the parent
					parent.Children.Add(tree); 
				else if (level - 1 > parent.TreeLevel) // If the new tree is a distant child of this tree, recursively add it to the last tree we processed
				{
					var newParent = parent.Children.Last();
					tree.Parent = newParent;
					newParent.Children.Add(tree);
					RecursivelyProcessToTree(lineEnumerator, tree, splitRegEx);
				}
				else // Otherwise, get the correct parent and recursively add it's children in
				{
					while (parent.TreeLevel >= 0 && parent.TreeLevel > level - 1)
						parent = parent.Parent;

					parent.Children.Add(tree);
				}
			}
		}

		dynamic RecursivelyFlattenToDynamic(Tree source)
		{
			return null;
		}
	}
}