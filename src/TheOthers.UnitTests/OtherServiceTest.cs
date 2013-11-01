using NUnit.Framework;
using System;

namespace TheOthers.UnitTests
{
	[TestFixture()]
	public class OtherServiceTest
	{
		[Test()]
		public void GetAllOthers_NoArgs_AllOthers ()
		{
			var actual = OtherService.GetAllOthers ();
			Assert.AreEqual (1, actual.Count);
			Assert.AreEqual ("Stub 1", actual [0].Name);
		}

		[Test()]
		public void CheckAllOthersStatus_NoArgs_AllOthersWithUpdatedStatus ()
		{
			var actual = OtherService.CheckAllOthersStatus ();
			Assert.AreEqual (1, actual.Count);
			Assert.AreEqual ("Stub 1", actual [0].Name);
			Assert.IsNotNull (actual [0].Status);
		}
	}
}