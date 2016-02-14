namespace SupportMe.Services.Data
{
    using System.Linq;
    using Contracts;
    using SupportMe.Data.Common.Constants;
    using SupportMe.Data.Common.Models;

    public abstract class BaseService<T> : IBaseService<T>
        where T : BaseModel<int>
    {
        protected IDbRepository<T> baseRepository;

        public virtual IQueryable<T> GetAll()
        {
            return this.baseRepository.All();
        }

        public virtual IQueryable<T> GetById(int id)
        {
            return this.baseRepository
                .All()
                .Where(c => c.Id == id);
        }

        public virtual T Delete(int id)
        {
            var model = this.baseRepository.GetById(id);
            this.baseRepository.Delete(model);
            this.baseRepository.SaveChanges();
            return model;
        }
    }
}
