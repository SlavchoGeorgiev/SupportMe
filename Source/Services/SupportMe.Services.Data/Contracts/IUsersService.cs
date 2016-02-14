namespace SupportMe.Services.Data.Contracts
{
    using System.Linq;
    using SupportMe.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetByUsername(string username);
    }
}
