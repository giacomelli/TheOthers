using NUnit.Framework;
using System;

namespace TheOthers.UnitTests
{
	[TestFixture()]
	public class ExternalDependencyServiceTest
	{
		[Test()]
		public void GetAllExternalDepencies_NoArgs_AllOthers ()
		{
			var actual = ExternalDependencyService.GetAllExternalDepencies ();
			Assert.AreEqual (1, actual.Count);
			Assert.AreEqual ("Stub 1", actual [0].Name);
		}

		[Test()]
		public void CheckAllExternalDependenciesStatus_NoArgs_AllOthersWithUpdatedStatus ()
		{
			var actual = ExternalDependencyService.CheckAllExternalDependenciesStatus ();
			Assert.AreEqual (1, actual.Count);
			Assert.AreEqual ("Stub 1", actual [0].Name);
			Assert.IsNotNull (actual [0].Status);
		}
	}
}