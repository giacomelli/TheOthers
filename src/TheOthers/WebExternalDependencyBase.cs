using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TheOthers
{
    /// <summary>
    /// A base IExternalDependency's implementation which check a HTTP status code of a web resource.
    /// </summary>
    public class WebExternalDependencyBase : ExternalDependencyBase
    {
        private string m_url;
        private HttpStatusCode m_expectedStatusCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="TheOthers.WebExternalDependencyBase"/> class.
        /// </summary>
        /// <param name="name">The external dependency name.</param>
        /// <param name="url">The web resource url.</param>
        /// <param name="expectedStatusCode">The expected HTTP status code.</param>
        protected WebExternalDependencyBase(string name, string url, HttpStatusCode expectedStatusCode)
            : base(name)
        {
            m_url = url;
            m_expectedStatusCode = expectedStatusCode;
        }        
        
        /// <summary>
        /// Performs the check status.
        /// </summary>
        /// <returns>The check status.</returns>
        protected internal override ExternalDependencyStatus PerformCheckStatus()
        {
            var result = new ExternalDependencyStatus();
            var request = (HttpWebRequest)HttpWebRequest.Create(m_url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == m_expectedStatusCode)
            {
                result.IsFailing = false;
            }
            else
            {
                result.IsFailing = true;
                result.Description = $"Expected HTTP status code was '{m_expectedStatusCode}', but the url '{m_url}' returns a status '{response.StatusCode}'.";
            }

            return result;
        }        
    }
}
