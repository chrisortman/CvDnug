using System.Web.Mvc;
using System.Web.Routing;
using Ketchup.Mvc.Testing;
using Ketchup.Web.Routing;
using NUnit.Framework;
using OldWebforms;
using Shouldly;

namespace Tests
{
    public class RouteTests : RouteTestBase
    {

        [SetUp]
        public void Setup()
        {
            RouteTable.Routes.Clear();
            Global.RegisterRoutes(RouteTable.Routes);

        }


        [Test]
        public void AboutRoute()
        {
            Url.RouteUrl("AboutUrl").ShouldBe("/About.aspx");
            "~/About.aspx".ShouldMapToWebFormsPage();
        }
    
    }
}