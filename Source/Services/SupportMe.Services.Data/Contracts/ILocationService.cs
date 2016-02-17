namespace SupportMe.Services.Data.Contracts
{
    using SupportMe.Data.Models;

    public interface ILocationService : IBaseService<Location>
    {
        Location Create(string name, int companyId);

        Location Update(int id, string name, int companyId);

        bool ContainsName(string name, int? exceptId = null);
    }
}
