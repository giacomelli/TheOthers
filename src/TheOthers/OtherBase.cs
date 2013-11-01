using System;
using System.Diagnostics;
using HelperSharp;

namespace TheOthers
{
	/// <summary>
	/// Base class for Others.
	/// </summary>
	public abstract class OtherBase : IOther
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="TheOthers.OtherBase"/> class.
		/// </summary>
		/// <param name="name">The Other's name.</param>
		protected OtherBase(string name)
		{
			ExceptionHelper.ThrowIfNullOrEmpty ("name", name);

			Name = name;
		}
		#endregion

		#region Properties
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the status.
		/// </summary>
		/// <value>The status.</value>
		public OtherStatus Status { get; private set;  }
		#endregion

		#region Methods
		/// <summary>
		/// Checks the status of the other.
		/// </summary>
		public void CheckStatus()
		{            
			try
			{
				var sw = new Stopwatch();
				sw.Start();
				Status = PerformCheckStatus();
				sw.Stop();

				if (String.IsNullOrWhiteSpace(Status.Description))
				{
					Status.Description = "Response time: {0}".With(sw.Elapsed);
				}
			}
			catch (Exception ex)
			{
				Status = new OtherStatus()
				{
					IsFailing = true,
					Description = ex.Message
				};
			}
			finally 
			{
				Status.Date = DateTime.Now;
			}
		}

		/// <summary>
		/// Performs the check status.
		/// </summary>
		/// <returns>The check status.</returns>
		internal protected abstract OtherStatus PerformCheckStatus();
		#endregion
	}
}

