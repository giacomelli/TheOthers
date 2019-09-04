using System;
using System.Configuration;
using System.Data.SqlClient;

namespace TheOthers
{
    /// <summary>
    /// A base IExternalDependency's implementation which check a status of a database connection.
    /// </summary>
    public abstract class DbExternalDependencyBase : ExternalDependencyBase
    {
        private string _connectionString;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="TheOthers.DbExternalDependencyBase"/> class.
        /// </summary>
        /// <param name="name">The external dependency name.</param>
        /// <param name="connectionStringName">The connection string name in the connectionString section.</param>
        protected DbExternalDependencyBase(string name, string connectionStringName)
            : base(name)
        {
            if (string.IsNullOrEmpty(connectionStringName))
                throw new ArgumentNullException(nameof(connectionStringName));

            var config = ConfigurationManager.ConnectionStrings[connectionStringName];

            if (config == null)
            {
                throw new ArgumentException($"The connection string with name '{connectionStringName}' does not exist on .config file.");
            }

            _connectionString = config.ConnectionString;
        }
        
        /// <summary>
        /// Performs the check status.
        /// </summary>
        /// <returns>The check status.</returns>
        protected internal override ExternalDependencyStatus PerformCheckStatus()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
            }

            return new ExternalDependencyStatus()
            {
                IsFailing = false
            };
        }        
    }
}
