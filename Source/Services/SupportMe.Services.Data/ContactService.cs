﻿namespace SupportMe.Services.Data
{
    using System;
    using Contracts;
    using SupportMe.Data.Common.Contracts;
    using SupportMe.Data.Models;

    public class ContactService : BaseService<Contact>, IContactService
    {
        private readonly IDbRepository<Company> companyRepository;

        public ContactService(
            IDbRepository<Contact> baseRepository,
            IDbRepository<Company> companyRepository)
        {
            this.companyRepository = companyRepository;
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

        public string SetTo(int holdeId, string holder, int contactId)
        {
            if (holder.ToLower() == "company")
            {
                var company = this.companyRepository
                    .GetById(holdeId);

                company.ContactId = contactId;
                this.companyRepository.SaveChanges();

                return $"Contact set to {company.Name}";
            } else if (holder.ToLower() == "location")
            {
                // TODO Implement it
                throw new NotImplementedException();
            } else if (holder.ToLower() == "user")
            {
                // TODO Implement it
                throw new NotImplementedException();
            }

            return "Error contact not set";
        }
    }
}
