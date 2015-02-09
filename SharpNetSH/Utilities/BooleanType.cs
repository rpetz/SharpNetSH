namespace Ignite.SharpNetSH
{
	public enum BooleanType
	{
		[BooleanValue("yes", "no")]
		YesNo,
		[BooleanValue("enabled", "disabled")]
		EnabledDisabled,
		[BooleanValue("true","false")]
		TrueFalse
	}
}