namespace SupportMe.Services.Data.Contracts
{
    using System.Linq;
    using SupportMe.Data.Models;

    public interface ITicketMessageService : IBaseService<TicketMassage>
    {
        TicketMassage Create(string content, decimal pricingUnits, int ticketId, string authorId);

        IQueryable<TicketMassage> GetAllForTicket(int ticketId);
    }
}
