namespace SupportMe.Services.Data
{
    using System.Linq;
    using Contracts;
    using SupportMe.Data.Common.Constants;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Common.Models;

    public abstract class BaseService<T> : IBaseService<T>
        where T : BaseModel<int>
    {
        protected IDbRepository<T> BaseRepository { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return this.BaseRepository.All();
        }

        public virtual IQueryable<T> GetById(int id)
        {
            return this.BaseRepository
                .All()
                .Where(c => c.Id == id);
        }

        public virtual T Delete(int id)
        {
            var model = this.BaseRepository.GetById(id);
            this.BaseRepository.Delete(model);
            this.BaseRepository.SaveChanges();
            return model;
        }
    }
}
