namespace Ignite.SharpNetSH
{
	public enum BooleanType
	{
		[BooleanValue("yes", "no")]
		YesNo,
		[BooleanValue("enable", "disable")]
		EnableDisable,
		[BooleanValue("true","false")]
		TrueFalse
	}
}