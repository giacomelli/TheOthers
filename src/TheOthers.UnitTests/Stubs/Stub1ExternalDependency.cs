using System;

namespace TheOthers.UnitTests
{
	public class Stub1ExternalDependency : ExternalDependencyBase
	{
		#region Constructors
		public Stub1ExternalDependency() : base("Stub 1")
		{
		}
		#endregion

		#region implemented abstract members of OtherBase
		protected internal override ExternalDependencyStatus PerformCheckStatus ()
		{
			return new ExternalDependencyStatus ();
		}
		#endregion
	}
}