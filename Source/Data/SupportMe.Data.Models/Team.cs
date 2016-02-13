namespace SupportMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Team : BaseModel<int>
    {
        private ICollection<User> users;

        public Team()
        {
            this.users = new HashSet<User>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
