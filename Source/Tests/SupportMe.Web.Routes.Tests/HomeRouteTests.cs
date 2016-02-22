namespace SupportMe.Web.Routes.Tests
{
    using System.Net.Http;
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;

    using NUnit.Framework;

    [TestFixture]
    public class HomeRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void Init()
        {
            this.routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(this.routeCollection);
        }

        [Test]
        public void TestDefaultRoute()
        {
            const string Url = "/";
            this.routeCollection.ShouldMap(Url).To<HomeController>(c => c.Index());
        }

        [Test]
        public void TestRouteHome()
        {
            const string Url = "/Home";
            this.routeCollection.ShouldMap(Url).To<HomeController>(c => c.Index());
        }

        [Test]
        public void TestRouteHomeIndex()
        {
            const string Url = "/Home/Index";
            this.routeCollection.ShouldMap(Url).To<HomeController>(c => c.Index());
        }
    }
}
