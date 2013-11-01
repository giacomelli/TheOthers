using System;

namespace TheOthers
{
	/// <summary>
	/// Represents a status of the other.
	/// </summary>
	public class OtherStatus
	{
		#region Properties
		/// <summary>
		/// Gets or sets if other is failing.
		/// </summary>
		public bool IsFailing { get; set; }

		/// <summary>
		/// Gets or sets a description about the status.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the date.
		/// </summary>
		public DateTime Date { get; set; }
		#endregion
	}
}

