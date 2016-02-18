namespace SupportMe.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class TicketMassage : BaseModel<int>
    {
        [Required]
        public string Content { get; set; }

        public decimal PricingUnits { get; set; }

        public int TicketId { get; set; }

        [ForeignKey("TicketId")]
        public virtual Ticket Ticket { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
    }
}
