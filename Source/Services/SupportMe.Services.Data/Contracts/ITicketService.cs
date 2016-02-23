namespace SupportMe.Services.Data.Contracts
{
    using System.Linq;
    using SupportMe.Data.Models;

    public interface ITicketService : IBaseService<Ticket>
    {
        Ticket Create(
                    string title,
                    TicketType type,
                    TicketState state,
                    TicketPriority priority,
                    int locationId,
                    string authorId);

        Ticket Update(
                    int id,
                    string title,
                    TicketType type,
                    TicketState state,
                    TicketPriority priority,
                    int locationId);

        IQueryable<Ticket> GetByAuthor(string userId);
    }
}
