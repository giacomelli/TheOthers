﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TheOthers.MvcSample.App_Start.TheOthers
{
    public class TwitterRestApiExternalDependency : WebExternalDependencyBase
    {
        public TwitterRestApiExternalDependency()
            : base("Twitter REST API", "https://api.twitter.com/oauth/authorize?oauth_token=Z6eEdO8MOmk394WozF5oKyuAv855l4Mlqo7hhlSLik", HttpStatusCode.OK)
        {
        }
    }
}