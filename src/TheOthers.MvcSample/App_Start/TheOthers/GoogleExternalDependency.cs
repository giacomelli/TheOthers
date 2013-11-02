using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TheOthers.MvcSample.App_Start.TheOthers
{
    public class GoogleExternalDependency : WebExternalDependencyBase
    {
        public GoogleExternalDependency()
            : base("Google", "http://www.google.com", HttpStatusCode.OK)
        {
        }
    }
}