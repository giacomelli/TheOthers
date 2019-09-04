using System.Net;

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