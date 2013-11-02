using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TheOthers.MvcSample.App_Start.TheOthers
{
    public class GitHubExternalDependency : WebExternalDependencyBase
    {
        public GitHubExternalDependency()
            : base("GitHub", "http://www.github.com", HttpStatusCode.OK)
        {
        }
    }
}