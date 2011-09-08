using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OldWebforms.Lib
{
    public static partial class ContentHelper
    {
         public static string JavascriptIncludes()
         {
             var scriptFiles = new[]
             {
                 "jquery-1.6.2.min.js",
                 "jquery-1.8.16.min.js",
                 "jquery-unobtrusive-ajax.min.js",
                 "jquery.validate.min.js",
                 "jquery.validate.unobtrusive.js",
                 "modernizr-2.0.6-development-only.js"
             };

             var sb = new StringBuilder();
             foreach(var script in scriptFiles)
             {
                 sb.AppendFormat("<script src=\"/scripts/{0}\" type=\"text/javascript\"></script>\n",script);
             }

             return sb.ToString();
         }

         public static IHtmlString JavascriptIncludes(this HtmlHelper html)
         {
             return new MvcHtmlString(JavascriptIncludes());
         }
    }

    public class JavascriptIncludesControl : WebControl
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            writer.Write(ContentHelper.JavascriptIncludes());
        }
    }
}