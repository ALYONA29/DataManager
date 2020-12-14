using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using DataAccessLayer.Repository;
using Models;
using Model;
using ServiceLayer.DTO;
using ServiceLayer.Infrastructure;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Service
{
    public class OrderService : IServiceOrder
    {
        public List<RequiredInformation> GetInformation(string connectionString)
        {
            List<Address> addresses = new List<Address>();
            AddressRepository addressRepository = new AddressRepository();
            addresses = addressRepository.Get(connectionString);
            List<Contact> contacts = new List<Contact>();
            ContactRepository contactRepository = new ContactRepository();
            contacts = contactRepository.Get(connectionString);
            List<Phone> phones = new List<Phone>();
            PhoneRepository phoneRepository = new PhoneRepository();
            phones = phoneRepository.Get(connectionString);
            List<PersonData> personsData = new List<PersonData>();
            PersonDataRepository personData = new PersonDataRepository();
            personsData = personData.Get(connectionString);
            List<Email> emails = new List<Email>();
            EmailRepository emailRepository = new EmailRepository();
            emails = emailRepository.Get(connectionString);
            List<RequiredInformation> information = new List<RequiredInformation>();
            for (int i = 0; i < addresses.Count; i++)
            {
                RequiredInformation required = new RequiredInformation();
                required.Address = addresses[i].PersonAddress;
                required.Contact = contacts[i].Name;
                required.Email = emails[i].EmailAddress;
                required.PhoneNumber = phones[i].PhoneNumber;
                required.LastName = personsData[i].LastName;
                required.FirstName = personsData[i].FirstName;
                information.Add(required);
            }
            return information;
        }
    }
}
