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
        /// Gets the The Others UI extensions.
        /// </summary>
        /// <param name="helper">The html helper.</param>
        /// <returns>The Others UI extensions.</returns>
        public static TheOthersUI TheOthers(this HtmlHelper helper)
        {
            return new TheOthersUI();
        }

        /// <summary>
        /// Renders a monitor of The Others using Twitter Bootstrap components.
        /// </summary>
        /// <param name="ui">The Other UI.</param>
        /// <returns>The html.</returns>
        public static TheOthersUI BootstrapMonitor(this TheOthersUI ui)
        {
            var others = ExternalDependencyService.CheckAllExternalDependenciesStatus();

            foreach (var other in others)
            {
                var panelClass = other.Status.IsFailing ? "danger" : "success";

                ui.Html.AppendFormat(
                @" 
                <div class='panel panel-{0}'>
                    <div class='panel-heading'>
                        <h3 class='panel-title'>{1}</h3>
                    </div>
                    <div class='panel-body'>
                        {2}
                    </div>
                </div>",
                       panelClass,
                       other.Name,
                       other.Status.Description);
            }

            return ui;
        }

        /// <summary>
        /// Renders a monitor of The Others using a basic html table.
        /// </summary>
        /// <param name="ui">The Other UI.</param>
        /// <returns>The html.</returns>
        public static TheOthersUI BasicTableMonitor(this TheOthersUI ui)
        {
            var others = ExternalDependencyService.CheckAllExternalDependenciesStatus();
            ui.Html.Append("<table border='1' width='100%'><tr><th>Name</th><th>Is failing?</th><th>Description</th></tr>");

            foreach (var other in others)
            {
                var panelClass = other.Status.IsFailing ? "danger" : "success";

                ui.Html.AppendFormat(
                @" 
                <tr>
                    <td>{0}</td>
                    <td>{1}</td>
                    <td>{2}</td>
                </tr>",
                      other.Name,
                      other.Status.IsFailing,
                      other.Status.Description);
            }

            ui.Html.Append("</table>");

            return ui;
        }
    }
}