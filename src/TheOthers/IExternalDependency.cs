using System;

namespace TheOthers
{
    /// <summary>
    /// Defines an interface to an external dependency. 
    /// An external dependency can be others systems, API, web service, database or any "other" that your application is dependent.
    /// </summary>
    public interface IExternalDependency
    {
        #region Properties
        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the status.
        /// </summary>
        ExternalDependencyStatus Status { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Checks the status of the external dependency.
        /// </summary>
        void CheckStatus();
        #endregion
    }
}
