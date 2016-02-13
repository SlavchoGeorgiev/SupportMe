namespace SupportMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Address : BaseModel<int>
    {
        private ICollection<Contact> contacts;

        public Address()
        {
            this.contacts = new HashSet<Contact>();
        }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Street { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(50)]
        public string ZipCode { get; set; }

        public virtual ICollection<Contact> Contacts
        {
            get { return this.contacts; }
            set { this.contacts = value; }
        }
    }
}
