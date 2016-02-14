namespace SupportMe.Services.Data.Contracts
{
    using System.Linq;
    using SupportMe.Data.Models;

    public interface ICompanyService : IBaseService<Company>
    {
        int Create(string name, int? contactId);

        Company Update(int id, string name, int? contactId);
    }
}
