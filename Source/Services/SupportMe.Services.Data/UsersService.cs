namespace SupportMe.Services.Data
{
    using System.Linq;
    using Contracts;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class UsersService : IUsersService
    {
        private IGenericRepository<User> usersRepository;

        public UsersService(IGenericRepository<User> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IQueryable<User> GetByUsername(string username)
        {
            var result = this.usersRepository
                .All()
                .Where(u => u.UserName == username);

            return result;
        }
    }
}
