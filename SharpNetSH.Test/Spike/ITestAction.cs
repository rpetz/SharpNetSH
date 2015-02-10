using System;
using System.Collections.Generic;

namespace Ignite.SharpNetSH.Test.Spike
{
	public interface ITestAction
	{
		void SimpleMethod();

		SimpleResponseObject SimpleResponseMethod();

		IEnumerable<MultiResponseObject> MultiResponseMethod();

		ComplexResponseObject ComplexResponseMethod();

		IEnumerable<ComplexResponseObject> ComplexMultiResponseMethod();

		GenericResponseObject<SimpleResponseObject> GenericResponseMethod();

		IEnumerable<GenericResponseObject<SimpleResponseObject>> GenericMultiResponseMethod();

		void MethodWithNull(int? testInt = null);

		void MethodWithEnum(TestEnum testEnum);

		void MethodWithDecoratedEnum(DecoratedEnum testEnum);

		void MethodWithBooleanTypeYesNo([ParameterName("testBooleanYesNo", BooleanType.YesNo)] bool yesNo,
										[ParameterName("testBooleanEnabledDisabled", BooleanType.EnabledDisabled)] bool enabledDisabled,
										[ParameterName("testBooleanTrueFalse", BooleanType.TrueFalse)] bool trueFalse);

		[MethodName("test")]
		void MethodWithNameDecoration();

		void MethodWithParameterNameDecoration([ParameterName("test")] String myParameter);

		[ResponseProcessor(typeof(CustomResponseProcessor))]
		String MethodWithCustomResponseProcessor();

		[ResponseProcessor(typeof(CustomMultiResponseProcessor))]
		IEnumerable<String> MethodWithCustomMultiResponseProcessor();

		[ResponseProcessor(typeof(OverriddenResponseProcessor))]
		SimpleResponseObject MethodWithOverriddenResponseProcessor();

		[ResponseProcessor(typeof(OverriddenMultiResponseProcessor))]
		IEnumerable<SimpleResponseObject> MethodWithOverriddenMultiResponseProcessor();

		[ResponseProcessor(typeof(object))]
		String MethodWithInvalidResponseProcessor();

		[ResponseProcessor(typeof(OverzealousResponseProcessor))]
		String MethodWithOverzealousResponseProcessor();
	}
}