namespace SupportMe.Services.Data
{
    using System.Linq;
    using Contracts;
    using Microsoft.AspNet.Identity;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class ContactService : BaseService<Contact>, IContactService
    {
        private readonly IDbRepository<Company> companyRepository;

        private readonly IDbRepository<Location> locationRepository;

        private readonly IGenericRepository<User> userRepository;

        public ContactService(
            IDbRepository<Contact> baseRepository,
            IDbRepository<Company> companyRepository,
            IDbRepository<Location> locationRepository,
            IGenericRepository<User> userRepository)
        {
            this.BaseRepository = baseRepository;
            this.companyRepository = companyRepository;
            this.locationRepository = locationRepository;
            this.userRepository = userRepository;
        }

        public Contact Create(string phoneNumber, string email, int? addressId)
        {
            var contact = new Contact()
            {
                PhoneNumber = phoneNumber,
                Email = email,
                AddressId = addressId
            };

            this.BaseRepository.Add(contact);
            this.BaseRepository.SaveChanges();

            return contact;
        }

        public Contact Update(int id, string phoneNumber, string email, int? addressId)
        {
            var contact = this.BaseRepository.GetById(id);
            contact.PhoneNumber = phoneNumber;
            contact.Email = email;
            contact.AddressId = addressId;
            this.BaseRepository.SaveChanges();

            return contact;
        }

        public string SetTo(string holderId, string holder, int contactId)
        {
            if (holder.ToLower() == "company")
            {
                var company = this.companyRepository
                    .GetById(int.Parse(holderId));

                if (company == null)
                {
                    return $"Error contact not set {holder} not found";
                }

                company.ContactId = contactId;
                this.companyRepository.SaveChanges();

                return $"Contact set to {company.Name}";
            }
            else if (holder.ToLower() == "location")
            {
                var location = this.locationRepository
                       .GetById(int.Parse(holderId));

                if (location == null)
                {
                    return $"Error contact not set {holder} not found";
                }

                location.ContactId = contactId;
                this.locationRepository.SaveChanges();

                return $"Contact set to {location.Name}";
            }
            else if (holder.ToLower() == "user")
            {
                var user = this.userRepository.GetById(holderId);

                if (user == null)
                {
                    return $"Error contact not set {holder} not found";
                }

                user.ContactId = contactId;

                this.userRepository.SaveChanges();
                return $"Contact set to {user.UserName}";
            }

            return "Error contact not set";
        }
    }
}
