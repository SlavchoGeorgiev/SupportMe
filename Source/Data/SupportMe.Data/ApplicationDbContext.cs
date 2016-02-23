namespace SupportMe.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    using SupportMe.Data.Models;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Company> Companies { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public IDbSet<Contact> Contacts { get; set; }

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }

        public IDbSet<TicketMassage> TicketMassages { get; set; }

        public IDbSet<RequestLog> RequestLogs { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public override int SaveChanges()
        {
            int baseResult;

            this.ApplyAuditInfoRules();
            try
            {
                baseResult = base.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            return baseResult;
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
