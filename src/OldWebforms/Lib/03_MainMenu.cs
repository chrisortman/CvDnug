using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace OldWebforms.Lib
{
    public class MainMenuProvider
    {
       public string GenerateHtml(string currentUrl, string currentPage,Func<string,string> virtualPathResolver)
       {
           var items = BuildMenu(currentUrl, currentPage);
             StringBuilder menuText = new StringBuilder();
            menuText.Append("<ul>");
            foreach (var item in items)
            {
                var menuitem = new MenuItem()
                                   {
                                       Text = item.Text,
                                       NavigateUrl = item.Url,
                                       Selected = item.Selected
                                   };

                menuText.Append("<li>");
                menuText.AppendFormat("<a href=\"{0}\" ", virtualPathResolver(menuitem.NavigateUrl));
                if (menuitem.Selected)
                {
                    menuText.Append("class=\"selected\"");
                }
                menuText.AppendFormat(">{0}</a></li>", menuitem.Text);
            }
            menuText.Append("</ul>");
            //menuText.Append("<div style=\"float:clear;\"></div>");
           return menuText.ToString();
       }
        public IEnumerable<NavigationMenuItem> BuildMenu(string currentUrl,string currentPage)
        {
           currentUrl = currentUrl.ToLower();
            

            var items = new List<NavigationMenuItem>();
            items.Add(new NavigationMenuItem("Home","~/Default.aspx",false));
            items.Add(new NavigationMenuItem("About","~/About.aspx",false));
            //var currentPage = Path.GetFileName(Request.FilePath);
            DetermineSelectedItem(currentUrl, items, currentPage);

            return items;

        }

        private static void DetermineSelectedItem(string currentUrl, IEnumerable<NavigationMenuItem> items, string currentPage)
        {
            foreach(var menuItem in items)
            {
                if (currentUrl.EndsWith(".aspx"))
                {
                    var menuPage = Path.GetFileName(menuItem.Url);
                    if (currentPage.Equals(menuPage, StringComparison.InvariantCultureIgnoreCase))
                    {
                        menuItem.Select();
                    }
                }
                else
                {
                    if (currentUrl.EndsWith(menuItem.Url.Substring(2)/*remove ~/ */, StringComparison.InvariantCultureIgnoreCase))
                    {
                        menuItem.Select();
                    }
                }
            }

            
        }
    }

    public class NavigationMenuItem
    {
        public NavigationMenuItem(string text, string url,bool selected)
        {
            Text = text;
            Url = url;
            Selected = selected;
        }

        public void Select()
        {
            Selected = true;
        }
        /// <summary>
        /// The text that should be displayed for the item
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; private set;}
        /// <summary>
        /// The virtual (~/SomePath) url for the menu item.
        /// YOU MUST DO RESOLUTION TO DISPLAY
        /// </summary>
        public string Url { get; private set;}

        /// <summary>
        /// If the menu item should be shown as selected
        /// </summary>
        public bool Selected { get; private set;}
        
    }

    public static class MenuHelper
    {
        public static IHtmlString NavMenu(this HtmlHelper html,UrlHelper url)
        {
            var menuBuilder = new MainMenuProvider();
            var request = html.ViewContext.HttpContext.Request;
            var menuText = menuBuilder.GenerateHtml(request.RawUrl, Path.GetFileName(request.FilePath),url.Content);
            return new MvcHtmlString(menuText);
        }
    }

    public partial class NavMenu : WebControl
    {
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            var menuBuilder = new MainMenuProvider();
            var request = this.Context.Request;
            var menuText = menuBuilder.GenerateHtml(request.RawUrl, Path.GetFileName(request.FilePath),Page.ResolveClientUrl);

            writer.Write(menuText);
        }
    }
}