namespace SupportMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Ticket : BaseModel<int>
    {
        private ICollection<TicketMassage> messages;

        public Ticket()
        {
            this.messages = new HashSet<TicketMassage>();
        }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public TicketPriority Priority { get; set; }

        public TicketType Type { get; set; }

        public TicketState State { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

        [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public virtual ICollection<TicketMassage> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
