using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TheOthers.MvcSample.App_Start.Others
{
    public class GoogleOther : WebOtherBase
    {
        public GoogleOther()
            : base("Google", "http://www.google.com", HttpStatusCode.NotFound)
        {
        }
    }
}