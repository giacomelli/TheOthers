using NUnit.Framework;
using System;

namespace TheOthers.UnitTests
{
	[TestFixture()]
	public class ExternalDependencyServiceTest
	{
		[Test()]
		public void GetAllNoArgs_AllOthers ()
		{
			var actual = ExternalDependencyService.GetAll ();
			Assert.AreEqual (1, actual.Count);
			Assert.AreEqual ("Stub 1", actual [0].Name);
		}

		[Test()]
		public void CheckAllStatus_NoArgs_AllOthersWithUpdatedStatus ()
		{
			var actual = ExternalDependencyService.CheckAllStatus ();
			Assert.AreEqual (1, actual.Count);
			Assert.AreEqual ("Stub 1", actual [0].Name);
			Assert.IsNotNull (actual [0].Status);
		}
	}
}