namespace SupportMe.Services.Data
{
    using Contracts;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class ContactService : BaseService<Contact>, IContactService
    {
        public ContactService(IDbRepository<Contact> baseRepository)
        {
            this.BaseRepository = baseRepository;
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
    }
}
