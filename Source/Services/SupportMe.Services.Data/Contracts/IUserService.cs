namespace SupportMe.Services.Data.Contracts
{
    using System.Linq;
    using Results;
    using SupportMe.Data.Models;

    public interface IUserService
    {
        IQueryable<User> GetByUsername(string username);

        IQueryable<User> GetAll();

        IQueryable<User> GetById(string id);

        UpdateUserResult Update(
            string id,
            string firstName,
            string lastName,
            string userName,
            string email,
            int locationId);

        User Delete(string id);
    }
}
