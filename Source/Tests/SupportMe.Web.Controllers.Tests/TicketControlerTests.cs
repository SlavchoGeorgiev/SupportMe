namespace SupportMe.Web.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Infrastructure.Mapping;
    using Moq;

    using NUnit.Framework;
    using Services.Data.Contracts;
    using TestStack.FluentMVCTesting;
    using ViewModels.Ticket;

    [TestFixture]
    public class TicketControlerTests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(TicketController).Assembly);
        }

        [Test]
        public void DetailsShouldRenderViewDetailsWithCorrectModelId()
        {
            const int modelId = 5;

            var ticketServiceMock = new Mock<ITicketService>();
            ticketServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(value: new List<Ticket>() { new Ticket() }.AsQueryable());

            var controller = new TicketController(ticketServiceMock.Object, null);
            controller.WithCallTo(x => x.Details(modelId))
                .ShouldRenderView("Details")
                .WithModel<TicketDetailsViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(modelId, viewModel.Id);
                    }).AndNoModelErrors();
        }

        [Test]
        public void GetTopOpenedShoudRednerPartialView_GetTopOpened()
        {
            var controller = new TicketController(null, null);
            controller.WithCallTo(x => x.GetTopOpened())
                .ShouldRenderPartialView("_GetTopOpened");
        }
    }
}
