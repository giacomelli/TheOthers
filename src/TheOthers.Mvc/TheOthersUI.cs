using System.Text;
using System.Web;

namespace TheOthers.Mvc
{
    /// <summary>
    /// Represents The Others UI.
    /// </summary>
    public sealed class TheOthersUI : IHtmlString
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TheOthersUI"/> class.
        /// </summary>
        public TheOthersUI()
        {
            Html = new StringBuilder();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the HTML.
        /// </summary>
        /// <value>
        /// The HTML.
        /// </value>
        internal StringBuilder Html { get; set; }
        #endregion

        #region Methods        
        /// <summary>
        /// Returns an HTML-encoded string.
        /// </summary>
        /// <returns>
        /// An HTML-encoded string.
        /// </returns>
        string IHtmlString.ToHtmlString()
        {
            return Html.ToString();
        }
        #endregion
    }
}
