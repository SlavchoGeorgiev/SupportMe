namespace SupportMe.Services.Data.Contracts
{
    using Results;
    using SupportMe.Data.Models;

    public interface IStatisticsService : IBaseService<Ticket>
    {
        TicketsCountByState TicketsCountByState();
    }
}
