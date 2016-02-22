namespace SupportMe.Services.Data
{
    using System.Linq;
    using Contracts;
    using Results;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class StatisticsService : BaseService<Ticket>, IStatisticsService
    {
        public StatisticsService(IDbRepository<Ticket> ticketRepository)
        {
            this.BaseRepository = ticketRepository;
        }

        public TicketsCountByState TicketsCountByState()
        {
            var result = new TicketsCountByState();
            result.Total = this.BaseRepository.All().Count();
            result.Open = this.BaseRepository.All().Count(t => t.State == TicketState.Open);
            result.Closed = this.BaseRepository.All().Count(t => t.State == TicketState.Closed);
            result.Hold = this.BaseRepository.All().Count(t => t.State == TicketState.Hold);
            return result;
        }
    }
}
