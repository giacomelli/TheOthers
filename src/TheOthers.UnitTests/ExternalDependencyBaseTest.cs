using NUnit.Framework;
using System;
using Rhino.Mocks;
using TestSharp;

namespace TheOthers.UnitTests
{
	[TestFixture]
	public class ExternalDependencyBaseTest
	{
		[Test]
		public void Constructor_NullOrEmptyName_Exception ()
		{	
			ExceptionAssert.IsThrowing (typeof(Exception), () => {
				MockRepository.GenerateMock<ExternalDependencyBase> ("");
			});
		}

		[Test]
		public void Constructor_Name_PropertySetted ()
		{
			var target = MockRepository.GenerateMock<ExternalDependencyBase> ("test name");
			Assert.AreEqual ("test name", target.Name);
			Assert.IsNull (target.Status);
		}

		[Test]
		public void CheckStatus_IsNotFailing_IsFailingFalse ()
		{
			var target = MockRepository.GenerateMock<ExternalDependencyBase> ("test name");
			target.Expect (t => t.PerformCheckStatus ()).Return (new ExternalDependencyStatus () { IsFailing = false });

			target.CheckStatus ();

			var actual = target.Status;
			Assert.IsFalse (actual.IsFailing);
			Assert.IsTrue (actual.Description.StartsWith ("Response time: "));
			Assert.AreEqual (DateTime.Now.Date, actual.Date.Date);

			target.VerifyAllExpectations ();
		}

		[Test]
		public void CheckStatus_IsFailing_IsFailingTrue ()
		{
			var target = MockRepository.GenerateMock<ExternalDependencyBase> ("test name");
			target.Expect (t => t.PerformCheckStatus ()).Return (new ExternalDependencyStatus () { IsFailing = true, Description = "failing" });

			target.CheckStatus ();

			var actual = target.Status;
			Assert.IsTrue (actual.IsFailing);
			Assert.AreEqual ("failing", actual.Description);
			Assert.AreEqual (DateTime.Now.Date, actual.Date.Date);

			target.VerifyAllExpectations ();
		}

		[Test]
		public void CheckStatus_Exception_IsFailingTrue ()
		{
			var target = MockRepository.GenerateMock<ExternalDependencyBase> ("test name");
			target.Expect (t => t.PerformCheckStatus ()).Throw (new Exception ("exception occurred"));

			target.CheckStatus ();

			var actual = target.Status;
			Assert.IsTrue (actual.IsFailing);
			Assert.AreEqual ("exception occurred", actual.Description);
			Assert.AreEqual (DateTime.Now.Date, actual.Date.Date);

			target.VerifyAllExpectations ();
		}
	}
}

