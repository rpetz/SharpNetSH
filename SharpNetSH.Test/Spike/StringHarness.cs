using System;

namespace Ignite.SharpNetSH.Test.Spike
{
	public class StringHarness : IExecutionHarness
	{
		private String _value;

		public String Value { get { return _value; } }

		public void Execute(string action)
		{
			_value = action;
		}
	}
}