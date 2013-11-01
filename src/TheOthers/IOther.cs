using System;

namespace TheOthers
{
	/// <summary>
	/// Defines an interface to an other. 
	/// An other can be another systems, api, web service, database or any other external dependency that your application is dependent.
	/// </summary>
	public interface IOther
	{
		#region Properties
		/// <summary>
		/// Gets the name.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the status.
		/// </summary>
		OtherStatus Status { get; }
		#endregion

		#region Methods
		/// <summary>
		/// Checks the status of the other.
		/// </summary>
		void CheckStatus();
		#endregion
	}
}

