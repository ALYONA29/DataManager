using ServiceLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataManager
{
    public class XmlGenerator
    {
        public void CreateXml(List<RequiredInformation> information)
        {
            XDocument xDocument = new XDocument();
            XElement people = new XElement("Persons");
            XElement person;
            XElement firstName;
            XElement lastName;
            XElement address;
            XElement email;
            XElement phone;
            XElement contact;

            foreach (RequiredInformation person1 in information)
            {
                person = new XElement("Person");
                firstName = new XElement("FirstName", person1.FirstName);
                lastName = new XElement("LastName", person1.LastName);
                address = new XElement("Address", person1.Address);
                email = new XElement("Email", person1.Email);
                phone = new XElement("Phone", person1.PhoneNumber);
                contact = new XElement("Contact", person1.Contact);
                person.Add(firstName, lastName, address, email, phone, contact);
                people.Add(person);
            }
            xDocument.Add(people);
            xDocument.Save("D:\\XmlFiles\\information" + DateTime.Now.ToString("MM/dd/yyyy") + ".xml");
        }
    }
}
