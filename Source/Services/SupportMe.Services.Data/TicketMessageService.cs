namespace SupportMe.Services.Data
{
    using System.Linq;
    using Contracts;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class TicketMessageService : BaseService<TicketMassage>, ITicketMessageService
    {
        public TicketMessageService(IDbRepository<TicketMassage> ticketMessageRepository)
        {
            this.BaseRepository = ticketMessageRepository;
        }

        public TicketMassage Create(string content, decimal pricingUnits, int ticketId, string authorId)
        {
            var ticketMessage = new TicketMassage()
            {
                Content = content,
                PricingUnits = pricingUnits,
                TicketId = ticketId,
                AuthorId = authorId
            };

            this.BaseRepository.Add(ticketMessage);
            this.BaseRepository.SaveChanges();
            return ticketMessage;
        }

        public IQueryable<TicketMassage> GetAllForTicket(int ticketId)
        {
            return this.GetAll()
                .Where(m => m.TicketId == ticketId)
                .OrderByDescending(m => m.CreatedOn);
        }
    }
}
