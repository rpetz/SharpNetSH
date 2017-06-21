using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public interface ITestAction
	{
		StandardResponse SimpleMethod();

		StandardResponse SimpleResponseMethod();

		StandardResponse MethodWithNull(int? testInt = null);

		StandardResponse MethodWithEnum(TestEnum testEnum);

		StandardResponse MethodWithDecoratedEnum(DecoratedEnum testEnum);

		StandardResponse MethodWithBooleanTypeYesNo([ParameterName("testBooleanYesNo", BooleanType.YesNo)] bool yesNo,
										[ParameterName("testBooleanEnableDisable", BooleanType.EnableDisable)] bool enableDisable,
										[ParameterName("testBooleanTrueFalse", BooleanType.TrueFalse)] bool trueFalse);

		[MethodName("test")]
		StandardResponse MethodWithNameDecoration();

		StandardResponse MethodWithParameterNameDecoration([ParameterName("test")] String myParameter);
	}
}