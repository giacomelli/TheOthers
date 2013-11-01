using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using HelperSharp;

namespace TheOthers
{
    /// <summary>
    /// A base IOther's implementation which check a HTTP status code of a web resource.
    /// </summary>
    public class WebOtherBase : OtherBase
    {
        #region Fields
		private string m_url;
        private HttpStatusCode m_expectedStatusCode;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="TheOthers.DbOther"/> class.
		/// </summary>
		/// <param name="name">The Other's name.</param>
		/// <param name="url">The web resource url.</param>
        /// <param name="expectedStatusCode">The expected HTTP status code.</param>
        protected WebOtherBase(string name, string url, HttpStatusCode expectedStatusCode)
            : base(name)
		{
            m_url = url;
            m_expectedStatusCode = expectedStatusCode;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Performs the check status.
		/// </summary>
		/// <returns>The check status.</returns>
		internal protected override OtherStatus PerformCheckStatus()
		{
            var result = new OtherStatus();
            var request = (HttpWebRequest) HttpWebRequest.Create(m_url);
            var response = (HttpWebResponse) request.GetResponse();

            if (response.StatusCode == m_expectedStatusCode)
            {
                result.IsFailing = false;
            }
            else
            {
                result.IsFailing = true;
                result.Description = "Expected HTTP status code was '{0}', but the url '{1}' returns a status '{2}'.".With(m_expectedStatusCode, m_url, response.StatusCode);
            }

            return result;
		}
		#endregion
    }
}
