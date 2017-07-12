using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH
{
	internal class Tree
	{
		public string RawText { get; set; }
		public string Title { get; set; }
		public dynamic Value { get; set; }
		public int TreeLevel { get; set; }
		public List<Tree> Children { get; set; }
		public Tree Parent { get; set; }

		public Tree()
		{
			TreeLevel = 0;
			RawText = "Root";
			Children = new List<Tree>();
			Parent = this;
		}

		public Tree(string rawText, int treeLevel, String splitRegEx)
		{
			RawText = rawText;
			if (splitRegEx != null)
			{
				var result = rawText.ProcessRawData(splitRegEx);
				Title = result.Key;
				Value = result.Value;
			}
			TreeLevel = treeLevel;
			Children = new List<Tree>();
		}

		public bool IsParentOf(Tree otherTree)
		{ return IsParentOf(otherTree.TreeLevel); }
		public bool IsParentOf(int level)
		{ return level > TreeLevel; }

		public bool IsSameLevelAs(Tree otherTree)
		{ return IsSameLevelAs(otherTree.TreeLevel); }
		public bool IsSameLevelAs(int level)
		{ return level == TreeLevel; }

		public override string ToString()
		{
			if (Title != null)
				return "{ Title: " + Title + ", Value: " + Value + ", Level: " + TreeLevel + ", Children: " + Children.Count + "}";
			return "{ Raw: " + RawText + ", Level: " + TreeLevel + ", Children: " + Children.Count + "}";
		}
	}
}