namespace SupportMe.Services.Data
{
    using Contracts;
    using SupportMe.Data.Common.Constants;
    using SupportMe.Data.Models;

    public class CompanyService : BaseService<Company>, ICompanyService
    {
        public CompanyService(IDbRepository<Company> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public int Create(string name, int? contactId)
        {
            var company = new Company()
            {
                Name = name,
                ContactId = contactId
            };

            this.baseRepository.Add(company);
            this.baseRepository.SaveChanges();

            return company.Id;
        }

        public Company Update(int id, string name, int? contactId)
        {
            var company = this.baseRepository.GetById(id);
            company.Name = name;
            company.ContactId = contactId;
            this.baseRepository.SaveChanges();

            return company;
        }
    }
}
