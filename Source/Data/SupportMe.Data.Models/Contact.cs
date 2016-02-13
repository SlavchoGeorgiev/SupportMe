namespace SupportMe.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Contact : BaseModel<int>
    {
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [MaxLength(254)]
        public string Email { get; set; }

        public int? AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}
