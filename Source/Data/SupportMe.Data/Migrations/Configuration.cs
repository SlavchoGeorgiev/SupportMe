namespace SupportMe.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SupportMe.Common;
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
            this.SeedUserSupport(context);
            this.SeedUserEmployees(context);
            this.SeedCompaniesLocationsContactsAndAddresses(context);
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

        private void SeedUserSupport(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "Support"))
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
                    UserName = "Support",
                    Email = "support@supportme.com",
                    FirstName = RandomGenerator.GetString(3, 8),
                    LastName = RandomGenerator.GetString(3, 8)
                };

                IdentityResult result = manager.Create(user, "password");
                if (result.Succeeded == false)
                {
                    throw new Exception(result.Errors.First());
                }

                manager.AddToRole(user.Id, UserRole.Support);

                for (int i = 1; i <= 5; i++)
                {
                    var userX = new User
                    {
                        UserName = $"Support{i}",
                        Email = $"support{i}@supportme.com",
                        FirstName = RandomGenerator.GetString(3, 8),
                        LastName = RandomGenerator.GetString(3, 8)
                    };

                    result = manager.Create(userX, "password");
                    if (result.Succeeded == false)
                    {
                        throw new Exception(result.Errors.First());
                    }

                    manager.AddToRole(userX.Id, UserRole.Support);
                }
            }
        }

        private void SeedUserEmployees(ApplicationDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == "Employee"))
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
                    UserName = "Employee",
                    Email = "employee@supportme.com",
                    FirstName = RandomGenerator.GetString(3, 8),
                    LastName = RandomGenerator.GetString(3, 8)
                };

                IdentityResult result = manager.Create(user, "password");
                if (result.Succeeded == false)
                {
                    throw new Exception(result.Errors.First());
                }

                manager.AddToRole(user.Id, UserRole.Employee);

                for (int i = 1; i <= 50; i++)
                {
                    var userX = new User
                    {
                        UserName = $"Employee{i}",
                        Email = $"employee{i}@supportme.com",
                        FirstName = RandomGenerator.GetString(3, 8),
                        LastName = RandomGenerator.GetString(3, 8)
                    };

                    result = manager.Create(userX, "password");
                    if (result.Succeeded == false)
                    {
                        throw new Exception(result.Errors.First());
                    }

                    manager.AddToRole(userX.Id, UserRole.Employee);
                }
            }
        }

        private void SeedCompaniesLocationsContactsAndAddresses(ApplicationDbContext context)
        {
            if (!context.Companies.Any())
            {
                for (int i = 1; i < 5; i++)
                {
                    var company = new Company() { Name = $"Ideal Sales {RandomGenerator.GetString(3, 10)}" };

                    company.Contact = new Contact()
                    {
                        PhoneNumber = RandomGenerator.GetInt(3, 10).ToString(),
                        Email = $"{RandomGenerator.GetString(3, 8)}@{RandomGenerator.GetString(3, 6)}.com",
                        Address = new Address()
                        {
                            Country = "Bulgaria",
                            City = "Sofia",
                            Street = $"{RandomGenerator.GetString(4, 8)} {RandomGenerator.GetString(4, 8)} str. {RandomGenerator.GetInt(6, 200)}",
                            ZipCode = RandomGenerator.GetInt(3000, 5000).ToString()
                        }
                    };

                    for (int j = 1; j < RandomGenerator.GetInt(3, 8); j++)
                    {
                        var location = new Location()
                        {
                            Name = $"{RandomGenerator.GetString(5, 10)} {company.Name} Branch",
                            Contact = new Contact()
                            {
                                PhoneNumber = RandomGenerator.GetInt(3, 10).ToString(),
                                Email = $"{RandomGenerator.GetString(3, 8)}@{RandomGenerator.GetString(3, 6)}.com",
                                Address = new Address()
                                {
                                    Country = "US",
                                    City = "LA",
                                    Street = $"{RandomGenerator.GetString(4, 8)} {RandomGenerator.GetString(4, 8)} avenu {RandomGenerator.GetInt(6, 200)}",
                                    ZipCode = RandomGenerator.GetInt(3000, 5000).ToString()
                                }
                            }
                        };

                        company.Locations.Add(location);
                    }

                    context.Companies.Add(company);
                    context.SaveChanges();
                }

                var users = context.Users.ToList();
                var locations = context.Locations.Select(l => new { Id = l.Id }).ToList();
                foreach (var user in users)
                {
                    user.LocationId = locations.OrderBy(l => Guid.NewGuid()).FirstOrDefault()?.Id;
                }

                context.SaveChanges();
            }
        }
    }
}
