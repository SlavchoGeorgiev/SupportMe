namespace SupportMe.Services.Data
{
    using System.Linq;
    using Contracts;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class LocationService : BaseService<Location>, ILocationService
    {
        public LocationService(IDbRepository<Location> baseRepository)
        {
            this.BaseRepository = baseRepository;
        }

        public Location Create(string name, int companyId)
        {
            var location = new Location()
            {
                Name = name,
                CompanyId = companyId
            };

            this.BaseRepository.Add(location);
            this.BaseRepository.SaveChanges();
            return location;
        }

        public Location Update(int id, string name, int companyId)
        {
            var location = this.BaseRepository.GetById(id);
            location.Name = name;
            location.CompanyId = companyId;
            this.BaseRepository.SaveChanges();

            return location;
        }

        public bool ContainsName(string name, int? exceptId = null)
        {
            var query = this.BaseRepository.AllWithDeleted();

            if (exceptId != null)
            {
                query = query.Where(l => l.Id != exceptId);
            }

            return query.Any(l => l.Name.ToLower() == name.ToLower());
        }
    }
}
