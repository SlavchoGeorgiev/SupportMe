namespace SupportMe.Services.Data
{
    using Contracts;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(IDbRepository<Company> baseRepository)
        {
            this.BaseRepository = baseRepository;
        }

        public int Create(string name, int? contactId)
        {
            var company = new Company()
            {
                Name = name,
                ContactId = contactId
            };

            this.BaseRepository.Add(company);
            this.BaseRepository.SaveChanges();

            return company.Id;
        }

        public Company Update(int id, string name, int? contactId)
        {
            var company = this.BaseRepository.GetById(id);
            company.Name = name;
            company.ContactId = contactId;
            this.BaseRepository.SaveChanges();

            return company;
        }
    }
}
