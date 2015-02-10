using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class StringHarness : IExecutionHarness
	{
		private String _value;

		public String Value { get { return _value; } }

		public IEnumerable<String> Execute(string action, out int exitCode)
		{
			_value = action;
			exitCode = 0;
			return new List<String>();
		}
	}
}