namespace SupportMe.Services.Data
{
    using System.Linq;
    using Contracts;
    using SupportMe.Data.Common.Constants;
    using SupportMe.Data.Models;

    public class CompanyService : ICompanyService
    {
        private IDbRepository<Company> companyRepository;

        public CompanyService(IDbRepository<Company> companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public IQueryable<Company> GetAll()
        {
            return this.companyRepository.All();
        }

        public IQueryable<Company> GetById(int id)
        {
            return this.companyRepository
                .All()
                .Where(c => c.Id == id);
        }

        public int Create(string name, int? contactId)
        {
            var company = new Company()
            {
                Name = name,
                ContactId = contactId
            };

            this.companyRepository.Add(company);
            this.companyRepository.SaveChanges();

            return company.Id;
        }

        public Company Update(int id, string name, int? contactId)
        {
            var company = this.companyRepository.GetById(id);
            company.Name = name;
            company.ContactId = contactId;
            this.companyRepository.SaveChanges();

            return company;
        }

        public Company Delete(int id)
        {
            var company = this.companyRepository.GetById(id);
            this.companyRepository.Delete(company);
            this.companyRepository.SaveChanges();
            return company;
        }
    }
}
