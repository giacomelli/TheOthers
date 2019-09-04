using System.Net;

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