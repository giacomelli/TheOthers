using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TheOthers
{
	/// <summary>
	/// A base IOther's implementation which check a status of a database connection.
	/// </summary>
	public abstract class DbOtherBase : OtherBase
	{
		#region Fields
		private string m_connectionString;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="TheOthers.DbOther"/> class.
		/// </summary>
		/// <param name="name">The Other's name.</param>
		/// <param name="connectionStringName">The connection string name in the connectionString section.</param>
		protected DbOtherBase(string name, string connectionStringName) : base(name)
		{
			m_connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Performs the check status.
		/// </summary>
		/// <returns>The check status.</returns>
		internal protected override OtherStatus PerformCheckStatus()
		{            
			using (var conn = new SqlConnection(m_connectionString))
			{
				conn.Open();
				conn.Close();
			}

			return new OtherStatus()
			{
				IsFailing = false
			};
		}
		#endregion
	}
}

