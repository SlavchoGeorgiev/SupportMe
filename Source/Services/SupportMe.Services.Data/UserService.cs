namespace SupportMe.Services.Data
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Results;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> usersRepository;

        private readonly UserManager<User> manager;

        private readonly DbContext context;

        public UserService(
            IGenericRepository<User> usersRepository,
            UserManager<User> manager,
            DbContext context)
        {
            this.usersRepository = usersRepository;
            this.manager = manager;
            this.context = context;
        }

        public IQueryable<User> GetByUsername(string username)
        {
            var result = this.manager.Users
                .Where(u => u.UserName == username);

            return result;
        }

        public IQueryable<User> GetAll()
        {
            return this.usersRepository.All();
        }

        public IQueryable<User> GetById(string id)
        {
            return this.usersRepository
                .All()
                .Where(u => u.Id == id);
        }

        public UpdateUserResult Update(string id, string firstName, string lastName, string userName, string email, int locationId)
        {
            var result = new UpdateUserResult();

            var user = this.GetById(id).FirstOrDefault();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.UserName = userName;
            user.Email = email;
            user.LocationId = locationId;

            result.Result = this.manager.Update(user);
            result.User = user;

            return result;
        }

        public User Delete(string id)
        {
            var model = this.usersRepository.GetById(id);
            this.usersRepository.Delete(model);
            this.usersRepository.SaveChanges();
            return model;
        }

        public IQueryable<IdentityRole> GetAllRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(this.context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            List<IdentityRole> roles = roleManager.Roles.ToList();

            return roles.AsQueryable();
        }

        public IEnumerable<string> GetUserRoles(string userId)
        {
            return this.manager.GetRoles<User, string>(userId);
        }

        public void UpdateRoles(string id, IEnumerable<string> roles)
        {
            this.manager.RemoveFromRoles(id, this.GetUserRoles(id).ToArray());
            if (roles != null || roles.Any())
            {
                this.manager.AddToRoles(id, roles.ToArray());
            }
        }

        public void AddAvatar(string id, string avatarFileName, string avatarFileExtension)
        {
            var user = this.usersRepository.GetById(id);
            user.AvatarFileName = avatarFileName;
            user.AvatarFileExtension = avatarFileExtension;
            this.usersRepository.Update(user);
            this.usersRepository.SaveChanges();
        }
    }
}
