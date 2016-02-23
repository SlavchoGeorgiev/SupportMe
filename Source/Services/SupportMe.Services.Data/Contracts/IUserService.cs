namespace SupportMe.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
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

        IQueryable<IdentityRole> GetAllRoles();

        IEnumerable<string> GetUserRoles(string userId);

        void UpdateRoles(string id, IEnumerable<string> roles);

        void AddAvatar(string id, string avatarFileName, string avatarFileExtension);
    }
}
