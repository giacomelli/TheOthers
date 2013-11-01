using System.Text;
using System.Web.Mvc;

namespace TheOthers.Mvc
{
	/// <summary>
	/// Html extensions for TheOthers.
	/// </summary>
	public static class HtmlExtensions
	{
        /// <summary>
        /// Renders a monitor of Others using Twitter Bootstrap components.
        /// </summary>
        /// <returns>The html.</returns>
        public static MvcHtmlString BootstrapMonitor(this HtmlHelper helper)
        {
            var others = OtherService.CheckAllOthersStatus();
            var html = new StringBuilder();

            foreach (var other in others)
            {
                var panelClass = other.Status.IsFailing ? "danger" : "success";

                html.AppendFormat(@" 
                <div class='panel panel-{0}'>
                    <div class='panel-heading'>
                        <h3 class='panel-title'>{1}</h3>
                    </div>
                    <div class='panel-body'>
                        {2}
                    </div>
                </div>", panelClass, other.Name, other.Status.Description);                
            }

            return new MvcHtmlString(html.ToString());
        }
	}
}

