using System;

namespace TheOthers.UnitTests
{
	public class Stub1Other : OtherBase
	{
		#region Constructors
		public Stub1Other() : base("Stub 1")
		{
		}
		#endregion

		#region implemented abstract members of OtherBase
		protected internal override OtherStatus PerformCheckStatus ()
		{
			return new OtherStatus ();
		}
		#endregion
	}
}