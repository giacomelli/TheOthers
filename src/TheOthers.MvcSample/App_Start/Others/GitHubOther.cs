using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TheOthers.MvcSample.App_Start.Others
{
    public class GitHubOther : WebOtherBase
    {
        public GitHubOther()
            : base("GitHub", "http://www.github.com", HttpStatusCode.OK)
        {
        }
    }
}