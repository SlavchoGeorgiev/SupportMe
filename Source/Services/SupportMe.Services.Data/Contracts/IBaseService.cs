namespace SupportMe.Services.Data.Contracts
{
    using System.Linq;
    using SupportMe.Data.Common.Models;
    using SupportMe.Data.Models;

    public interface IBaseService<T>
        where T : BaseModel<int>
    {
        IQueryable<T> GetAll();

        IQueryable<T> GetById(int id);

        T Delete(int id);
    }
}
