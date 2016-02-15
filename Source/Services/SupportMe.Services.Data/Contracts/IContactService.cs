namespace SupportMe.Services.Data.Contracts
{
    using SupportMe.Data.Models;

    public interface IContactService : IBaseService<Contact>
    {
        Contact Create(string phoneNumber, string email, int? addressId);

        Contact Update(int id, string phoneNumber, string email, int? addressId);
    }
}
