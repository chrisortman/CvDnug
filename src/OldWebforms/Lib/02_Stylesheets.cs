using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OldWebforms.Lib
{
 public static partial class ContentHelper
    {
         public static string StylesheetIncludes()
         {
             var cssFiles = new[]
             {
                 /*
                  * The order is on purpose here,
                  * jquery is first so that your own stylesheets can override it
                  * The webforms stylesheet comes last because that would be 
                  * the existing stylesheet which i want to have precedence over 
                  * anything declared in boiler plate mvc project
                  */
                "/content/themes/base/jquery.ui.all.css",
                "/content/site.css",
                "/Styles/Site.css"
             };

             var sb = new StringBuilder();
             foreach(var stylesheet in cssFiles)
             {
                 sb.AppendFormat("<link href=\"{0}\" type=\"text/css\" rel=\"stylesheet\" />\n",stylesheet);
             }

             return sb.ToString();
         }

         public static IHtmlString StylesheetIncludes(this HtmlHelper html)
         {
             return new MvcHtmlString(StylesheetIncludes());
         }
    }

    public class StylesheetIncludesControl : WebControl
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.Write(ContentHelper.StylesheetIncludes());
        }
    }
}