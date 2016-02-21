namespace SupportMe.Services.Data.Contracts
{
    using SupportMe.Data.Models;

    public interface ITicketMassageService : IBaseService<TicketMassage>
    {
        TicketMassage Create(string content, decimal pricingUnits, int ticketId, string authorId);
    }
}
