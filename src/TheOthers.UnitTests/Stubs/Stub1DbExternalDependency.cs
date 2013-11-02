using System;

namespace TheOthers.UnitTests
{
	public class Stub1DbExternalDependency : DbExternalDependencyBase
	{
		#region Constructors
		public Stub1DbExternalDependency(string name, string connectionString) : base(name, connectionString)
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