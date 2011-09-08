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
                "/content/themes/base/jquery.ui.all.css",
                "/content/site.css"
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