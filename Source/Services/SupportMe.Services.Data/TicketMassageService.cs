namespace SupportMe.Services.Data
{
    using System.Linq;
    using Contracts;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class TicketMassageService : BaseService<TicketMassage>, ITicketMassageService
    {
        public TicketMassageService(IDbRepository<TicketMassage> ticketMassageRepository)
        {
            this.BaseRepository = ticketMassageRepository;
        }

        public TicketMassage Create(string content, decimal pricingUnits, int ticketId, string authorId)
        {
            var ticketMassage = new TicketMassage()
            {
                Content = content,
                PricingUnits = pricingUnits,
                TicketId = ticketId,
                AuthorId = authorId
            };

            this.BaseRepository.Add(ticketMassage);
            this.BaseRepository.SaveChanges();
            return ticketMassage;
        }

        public IQueryable<TicketMassage> GetAllForTicket(int ticketId)
        {
            return this.GetAll()
                .Where(m => m.TicketId == ticketId)
                .OrderByDescending(m => m.CreatedOn);
        }
    }
}
