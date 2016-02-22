namespace SupportMe.Web.Routes.Tests
{
    using System.Net.Http;
    using System.Web.Routing;
    using Controllers;
    using MvcRouteTester;

    using NUnit.Framework;

    [TestFixture]
    public class TicketRouteTests
    {
        private RouteCollection routeCollection;

        [TestFixtureSetUp]
        public void Init()
        {
            this.routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(this.routeCollection);
        }

        [Test]
        public void TestRouteTicketGetCreate()
        {
            const string Url = "/Ticket/Create";
            this.routeCollection.ShouldMap(HttpMethod.Get, Url).To<TicketController>(c => c.Create());
        }

        [Test]
        public void TestRouteTicketPostCreate()
        {
            const string Url = "/Ticket/Create";
            this.routeCollection.ShouldMap(HttpMethod.Post, Url).To<TicketController>(c => c.Create(null));
        }

        [Test]
        public void TestRouteTicketGetDetails()
        {
            const string Url = "/Ticket/Details/15";
            this.routeCollection.ShouldMap(HttpMethod.Get, Url).To<TicketController>(c => c.Details(15));
        }

        [Test]
        public void TestRouteTicketGetTicketInfo()
        {
            const string Url = "/Ticket/TicketInfo/15";
            this.routeCollection.ShouldMap(HttpMethod.Get, Url).To<TicketController>(c => c.TicketInfo(15));
        }

        [Test]
        public void TestRouteTicketGetEdit()
        {
            const string Url = "/Ticket/Edit/15";
            this.routeCollection.ShouldMap(HttpMethod.Get, Url).To<TicketController>(c => c.Edit(15));
        }

        [Test]
        public void TestRouteTicketPostEdit()
        {
            const string Url = "/Ticket/Edit";
            this.routeCollection.ShouldMap(HttpMethod.Post, Url).To<TicketController>(c => c.Edit(null));
        }

        [Test]
        public void TestRouteTicketGetTopOpened()
        {
            const string Url = "/Ticket/GetTopOpened";
            this.routeCollection.ShouldMap(HttpMethod.Get, Url).To<TicketController>(c => c.GetTopOpened());
        }

        [Test]
        public void TestRouteTicketGetAllInGrid()
        {
            const string Url = "/Ticket/GetAllInGrid";
            this.routeCollection.ShouldMap(HttpMethod.Get, Url).To<TicketController>(c => c.GetAllInGrid());
        }

        [Test]
        public void TestRouteTicketPostReadAll()
        {
            const string Url = "/Ticket/ReadAll";
            this.routeCollection.ShouldMap(HttpMethod.Post, Url).To<TicketController>(c => c.ReadAll(null));
        }
    }
}
