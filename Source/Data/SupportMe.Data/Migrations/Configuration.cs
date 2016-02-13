namespace SupportMe.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using SupportMe.Data.Common.Constants;
    using SupportMe.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            // TODO: Fix it in poduction
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedUserRoles(context);
            this.SeedUserAdmin(context);
        }

        private void SeedUserRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var roleAdmin = new IdentityRole { Name = UserRole.Admin };
                var roleSupport = new IdentityRole { Name = UserRole.Support };
                var roleEmployee = new IdentityRole { Name = UserRole.Employee };
                var roleCompanyManager = new IdentityRole { Name = UserRole.CompanyManager };

                manager.Create(roleAdmin);
                manager.Create(roleSupport);
                manager.Create(roleEmployee);
                manager.Create(roleCompanyManager);
            }
        }

        private void SeedUserAdmin(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = false,
                    RequireDigit = false,
                    RequireLowercase = false,
                    RequireUppercase = false,
                };

                var user = new User
                {
                    UserName = "Admin",
                    Email = "admin@supportme.com"
                };

                IdentityResult result = manager.Create(user, "password");
                if (result.Succeeded == false)
                {
                    throw new Exception(result.Errors.First());
                }

                manager.AddToRole(user.Id, UserRole.Admin);
            }
        }
    }
}
