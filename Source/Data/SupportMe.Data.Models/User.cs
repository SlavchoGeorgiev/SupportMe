namespace SupportMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Team> teams;

        private ICollection<Ticket> ticket;

        public User()
        {
            this.teams = new HashSet<Team>();
            this.ticket = new HashSet<Ticket>();
        }

        [MaxLength(80)]
        public string FirstName { get; set; }

        [MaxLength(80)]
        public string LastName { get; set; }

        public int? ContactId { get; set; }

        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }

        public int? LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public virtual ICollection<Ticket> Tickets
        {
            get { return this.ticket; }
            set { this.ticket = value; }
        }

        public virtual ICollection<Team> Teams
        {
            get { return this.teams; }
            set { this.teams = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }
    }
}
