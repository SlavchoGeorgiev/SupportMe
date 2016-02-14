namespace SupportMe.Services.Data
{
    using Contracts;
    using SupportMe.Data.Common.Constants;
    using SupportMe.Data.Models;

    public class AddressService : BaseService<Address>, IAddressService
    {
        public AddressService(IDbRepository<Address> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public Address Create(string country, string city, string street, string state, string zipCode)
        {
            var address = new Address()
            {
                Country = country,
                City = city,
                Street = street,
                State = state,
                ZipCode = zipCode
            };

            this.baseRepository.Add(address);
            this.baseRepository.SaveChanges();

            return address;
        }

        public Address Update(int id, string country, string city, string street, string state, string zipCode)
        {
            var address = this.baseRepository.GetById(id);
            address.Country = country;
            address.City = city;
            address.Street = street;
            address.State = state;
            address.ZipCode = zipCode;
            this.baseRepository.SaveChanges();

            return address;
        }
    }
}
