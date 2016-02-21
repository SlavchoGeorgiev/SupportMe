namespace SupportMe.Services.Data
{
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
    }
}
