namespace SupportMe.Services.Data.Contracts
{
    using SupportMe.Data.Models;

    public interface IAddressService : IBaseService<Address>
    {
        Address Create(string country, string city, string street, string state, string zipCode);

        Address Update(int id, string country, string city, string street, string state, string zipCode);
    }
}