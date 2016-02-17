namespace SupportMe.Services.Data
{
    using System.Linq;
    using Contracts;
    using Microsoft.AspNet.Identity;
    using Results;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> usersRepository;

        private readonly UserManager<User> manager;

        public UserService(
            IGenericRepository<User> usersRepository,
            UserManager<User> manager)
        {
            this.usersRepository = usersRepository;
            this.manager = manager;
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

            result.result = this.manager.Update(user);
            result.user = user;

            return result;
        }

        public User Delete(string id)
        {
            var model = this.usersRepository.GetById(id);
            this.usersRepository.Delete(model);
            this.usersRepository.SaveChanges();
            return model;
        }
    }
}
