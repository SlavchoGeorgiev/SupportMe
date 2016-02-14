namespace SupportMe.Services.Data.Contracts
{
    using System.Linq;
    using SupportMe.Data.Models;

    public interface ICompanyService
    {
        IQueryable<Company> GetAll();

        IQueryable<Company> GetById(int id);

        int Create(string name, int? contactId);

        Company Update(int id, string name, int? contactId);

        Company Delete(int id);
    }
}
