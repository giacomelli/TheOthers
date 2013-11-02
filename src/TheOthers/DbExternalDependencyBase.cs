using System;
using System.Configuration;
using System.Data.SqlClient;
using HelperSharp;

namespace TheOthers
{
    /// <summary>
    /// A base IExternalDependency's implementation which check a status of a database connection.
    /// </summary>
    public abstract class DbExternalDependencyBase : ExternalDependencyBase
    {
        #region Fields
        private string m_connectionString;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TheOthers.DbExternalDependencyBase"/> class.
        /// </summary>
        /// <param name="name">The external dependency name.</param>
        /// <param name="connectionStringName">The connection string name in the connectionString section.</param>
        protected DbExternalDependencyBase(string name, string connectionStringName)
            : base(name)
        {
            ExceptionHelper.ThrowIfNullOrEmpty("connectionStringName", connectionStringName);

            var config = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (config == null)
            {
                throw new ArgumentException("The connection string with name '{0}' does not exist on .config file.".With(connectionStringName));
            }

            m_connectionString = config.ConnectionString;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Performs the check status.
        /// </summary>
        /// <returns>The check status.</returns>
        protected internal override ExternalDependencyStatus PerformCheckStatus()
        {
            using (var conn = new SqlConnection(m_connectionString))
            {
                conn.Open();
            }

            return new ExternalDependencyStatus()
            {
                IsFailing = false
            };
        }
        #endregion
    }
}
