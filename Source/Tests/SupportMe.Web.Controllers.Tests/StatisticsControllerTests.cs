namespace SupportMe.Web.Controllers.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Models;
    using Infrastructure.Mapping;
    using Moq;

    using NUnit.Framework;
    using Services.Data.Contracts;
    using Services.Data.Results;
    using TestStack.FluentMVCTesting;
    using ViewModels.Statistics;
    using ViewModels.Ticket;

    [TestFixture]
    public class StatisticsControllerTests
    {
        [TestFixtureSetUp]
        public void Init()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(StatisticsController).Assembly);
        }

        [Test]
        public void TicketStatePieShouldRenderCorrectPartialView()
        {
            var statisticsService = new Mock<IStatisticsService>();
            statisticsService.Setup(x => x.TicketsCountByState())
                .Returns(new TicketsCountByState());

            var controller = new StatisticsController(statisticsService.Object);
            controller.WithCallTo(x => x.TicketStatePie())
                .ShouldRenderPartialView("_TicketStatePie");
        }

        [Test]
        public void TicketStatePieShouldWorkWithZeroAsTotal()
        {
            var statisticsService = new Mock<IStatisticsService>();
            statisticsService.Setup(x => x.TicketsCountByState())
                .Returns(new TicketsCountByState()
                {
                    Total = 0,
                    Open = 0,
                    Closed = 0,
                    Hold = 0
                });

            var controller = new StatisticsController(statisticsService.Object);
            controller.WithCallTo(x => x.TicketStatePie())
                .ShouldRenderPartialView("_TicketStatePie");
        }

        [Test]
        public void TicketStatePieShouldReturnCorrectViewModel()
        {
            const decimal total = 100;
            const decimal open = 30;
            const decimal closed = 50;
            const decimal hold = 20;

            var statisticsService = new Mock<IStatisticsService>();
            statisticsService.Setup(x => x.TicketsCountByState())
                .Returns(new TicketsCountByState()
                {
                    Total = (int)total,
                    Open = (int)open,
                    Closed = (int)closed,
                    Hold = (int)hold
                });

            var controller = new StatisticsController(statisticsService.Object);
            controller.WithCallTo(x => x.TicketStatePie())
                .ShouldRenderPartialView("_TicketStatePie")
                .WithModel<IEnumerable<TicketStatePieViewModel>>(
                    viewModel =>
                    {
                        foreach (var item in viewModel)
                        {
                            switch (item.Source)
                            {
                                case "Open": Assert.AreEqual(open / total * 100, item.Percentage);
                                    break;
                                case "Closed": Assert.AreEqual(closed / total * 100, item.Percentage);
                                    break;
                                case "On Hold":
                                    Assert.AreEqual(hold / total * 100, item.Percentage);
                                    break;
                            }
                        }
                    }).AndNoModelErrors();
        }
    }
}
