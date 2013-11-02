using System;

namespace TheOthers.MvcSample
{
	public class LegacySystemExternalDependecy : ExternalDependencyBase
	{
		#region Constructors
		public LegacySystemExternalDependecy () : base("Legacy system")
		{
		}
		#endregion

		#region implemented abstract members of ExternalDependencyBase
		protected override ExternalDependencyStatus PerformCheckStatus ()
		{
			// TODO: perform the check against the legacy system api.
			throw new NotImplementedException ();
		}
		#endregion
	}
}

