using System;

namespace TheOthers
{
    /// <summary>
    /// Represents a status of the external dependency.
    /// </summary>
    public class ExternalDependencyStatus
    {
        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether the external dependency is failing.
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
