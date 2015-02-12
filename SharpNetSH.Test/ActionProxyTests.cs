using System;
using Ignite.SharpNetSH.Test.Spike;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ignite.SharpNetSH.Test
{
	[TestClass]
	public class ActionProxyTests
	{
		[TestMethod]
		public void ShouldOperateOnInterface()
		{
			var harness = new StringHarness();
			var proxy = ActionProxy<ITestAction>.Create("testActionName", "netsh unittest", harness);
			proxy.SimpleMethod();
			Assert.AreEqual("netsh unittest testActionName SimpleMethod", harness.Value);
		}

		[TestMethod]
		public void ShouldCallExecutionHarness()
		{
			var harness = new Mock<IExecutionHarness>();
			var proxy = ActionProxy<ITestAction>.Create("test", "netsh unittest", harness.Object);
			proxy.SimpleMethod();
			int exitCode;
			harness.Verify(x => x.Execute(It.IsAny<String>(), out exitCode), Times.Once());
		}

		[TestMethod]
		public void ShouldCallIRequestProcessor()
		{
			var harness = new Mock<IExecutionHarness>();
			var proxy = ActionProxy<ITestAction>.Create("test", "netsh unittest", harness.Object);
			var response = proxy.SimpleResponseMethod();
			Assert.IsNotNull(response);
			Assert.IsInstanceOfType(response, typeof(StandardResponse));
		}

		[TestMethod]
		public void ShouldSupportNullParameters()
		{
			var harness = new StringHarness();
			var proxy = ActionProxy<ITestAction>.Create("testActionName", "netsh unittest", harness);
			proxy.MethodWithNull();
			Assert.AreEqual("netsh unittest testActionName MethodWithNull", harness.Value);
			proxy.MethodWithNull(1);
			Assert.AreEqual("netsh unittest testActionName MethodWithNull testInt=1", harness.Value);
		}

		[TestMethod]
		public void ShouldSupportEnumerationParameters()
		{
			var harness = new StringHarness();
			var proxy = ActionProxy<ITestAction>.Create("testActionName", "netsh unittest", harness);
			proxy.MethodWithNull();
			Assert.AreEqual("netsh unittest testActionName MethodWithNull", harness.Value);
			proxy.MethodWithNull(1);
			Assert.AreEqual("netsh unittest testActionName MethodWithNull testInt=1", harness.Value);
		}

		[TestMethod]
		public void ShouldSupportBooleanDescriptionDecoratedEnumerations()
		{
			var harness = new StringHarness();
			var proxy = ActionProxy<ITestAction>.Create("testActionName", "netsh unittest", harness);
			proxy.MethodWithEnum(TestEnum.Value1);
			Assert.AreEqual("netsh unittest testActionName MethodWithEnum testEnum=Value1", harness.Value);
			proxy.MethodWithEnum(TestEnum.Value2);
			Assert.AreEqual("netsh unittest testActionName MethodWithEnum testEnum=Value2", harness.Value);
		}

		[TestMethod]
		public void ShouldSupportBooleanValueDecoratedEnumerations()
		{
			var harness = new StringHarness();
			var proxy = ActionProxy<ITestAction>.Create("testActionName", "netsh unittest", harness);
			proxy.MethodWithDecoratedEnum(DecoratedEnum.Value1);
			Assert.AreEqual("netsh unittest testActionName MethodWithDecoratedEnum testEnum=value1", harness.Value);
			proxy.MethodWithDecoratedEnum(DecoratedEnum.Value2);
			Assert.AreEqual("netsh unittest testActionName MethodWithDecoratedEnum testEnum=value2", harness.Value);
		}

		[TestMethod]
		public void ShouldSupportEnumTypeDecoratedParameters()
		{
			var harness = new StringHarness();
			var proxy = ActionProxy<ITestAction>.Create("testActionName", "netsh unittest", harness);
			proxy.MethodWithDecoratedEnum(DecoratedEnum.Value1);
			Assert.AreEqual("netsh unittest testActionName MethodWithDecoratedEnum testEnum=value1", harness.Value);
			proxy.MethodWithDecoratedEnum(DecoratedEnum.Value2);
			Assert.AreEqual("netsh unittest testActionName MethodWithDecoratedEnum testEnum=value2", harness.Value);
		}

		[TestMethod]
		public void ShouldSupportBooleanTypeDecoratedParameters()
		{
			var harness = new StringHarness();
			var proxy = ActionProxy<ITestAction>.Create("testActionName", "netsh unittest", harness);
			proxy.MethodWithBooleanTypeYesNo(true, false, true);
			Assert.AreEqual("netsh unittest testActionName MethodWithBooleanTypeYesNo testBooleanYesNo=yes testBooleanEnabledDisabled=disabled testBooleanTrueFalse=true", harness.Value);
			proxy.MethodWithBooleanTypeYesNo(false, true, false);
			Assert.AreEqual("netsh unittest testActionName MethodWithBooleanTypeYesNo testBooleanYesNo=no testBooleanEnabledDisabled=enabled testBooleanTrueFalse=false", harness.Value);
		}

		[TestMethod]
		public void ShouldSupportMethodNameDecoratedMethods()
		{
			var harness = new StringHarness();
			var proxy = ActionProxy<ITestAction>.Create("testActionName", "netsh unittest", harness);
			proxy.MethodWithNameDecoration();
			Assert.AreEqual("netsh unittest testActionName test", harness.Value);
		}

		[TestMethod]
		public void ShouldSupportParameterNameDecoratedMethods()
		{
			var harness = new StringHarness();
			var proxy = ActionProxy<ITestAction>.Create("testActionName", "netsh unittest", harness);
			proxy.MethodWithParameterNameDecoration("myParameterTest");
			Assert.AreEqual("netsh unittest testActionName MethodWithParameterNameDecoration test=myParameterTest", harness.Value);
		}
	}
}