namespace SupportMe.Services.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Contracts;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class TicketService : BaseService<Ticket>, ITicketService
    {
        public TicketService(IDbRepository<Ticket> ticketRepository)
        {
            this.BaseRepository = ticketRepository;
        }

        public Ticket Create(string title, TicketType type, TicketState state, TicketPriority priority, int locationId, string authorId)
        {
            var ticket = new Ticket()
            {
                Title = title,
                State = state,
                Type = type,
                Priority = priority,
                LocationId = locationId,
                AuthorId = authorId
            };

            this.BaseRepository.Add(ticket);
            this.BaseRepository.SaveChanges();
            return ticket;
        }

        public Ticket Update(int id, string title, TicketType type, TicketState state, TicketPriority priority, int locationId)
        {
            var ticket = this.BaseRepository.GetById(id);

            ticket.Title = title;
            ticket.Type = type;
            ticket.State = state;
            ticket.Priority = priority;
            ticket.LocationId = locationId;

            this.BaseRepository.SaveChanges();

            return ticket;
        }

        public IQueryable<Ticket> GetByAuthor(string userId)
        {
            return this.BaseRepository.All().Where(t => t.AuthorId == userId);
        }
    }
}
