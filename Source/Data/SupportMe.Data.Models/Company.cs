namespace SupportMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Company : BaseModel<int>
    {
        private ICollection<Location> locations;

        public Company()
        {
            this.locations = new HashSet<Location>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int ContactId { get; set; }

        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }

        public virtual ICollection<Location> Locations
        {
            get { return this.locations; }
            set { this.locations = value; }
        }
    }
}
