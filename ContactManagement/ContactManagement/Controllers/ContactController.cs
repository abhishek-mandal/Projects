using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactManagement.Models;
using DataAccessLayer;
using System.Web.Mvc;

namespace ContactManagement.Controllers
{
    public class ContactController : ApiController
    {
        IContactDatabase _objContactDatabase;

        public ContactController()
        {         
        }

        public ContactController(IContactDatabase objContactDatabase)
        {
           _objContactDatabase = objContactDatabase;
        }

        // GET api/values/5
        public List<ContactDetails> GetAllContacts()
        {
            ContactDatabase contactDatabase = new ContactDatabase();
            var contactList = contactDatabase.GetAllContacts();
            var allcontacts = (from c in contactList
                       select new ContactDetails
                       {
                           Id = c.Id,
                           FirstName = c.FirstName,
                           LastName = c.LastName,
                           Email = c.Email,
                           PhoneNumber = c.PhoneNumber,
                           IsActive = c.Status
                       }).ToList();

            ///To Save a Contact
            ///Post("xyz","lmn","abc@gmail.com",12345);

            ///Delete a Contact
            ///Delete(3); --Id to deleted

            return allcontacts;
        }

        public ContactDetails GetContactById(int id)
        {
            ContactDatabase contactDatabase = new ContactDatabase();
            var contact = contactDatabase.GetContactById(id);
            
            var contactInfo = new ContactDetails
                               {
                                   Id=contact.Id,
                                   FirstName = contact.FirstName,
                                   LastName = contact.LastName,
                                   Email = contact.Email,
                                   PhoneNumber = contact.PhoneNumber
                               };
            return contactInfo;
        }

        
        // POST api/Contact
        public void Post(string firstName, string lastName, string email, int phnNum)
        {
            ContactDatabase contactDatabase = new ContactDatabase();
            Contact contactList = contactDatabase.SaveContact(firstName, lastName, email, phnNum);

            var newContact = new ContactDetails {                                                            
                                   FirstName = contactList.FirstName,
                                   LastName = contactList.LastName,
                                   Email = contactList.Email,
                                   PhoneNumber = contactList.PhoneNumber
                                };
        }

        // PUT api/Contact/5
        public void Put(int id, string firstName, string lastName, string email, int phnNum)
        {
            ContactDatabase contactDatabase = new ContactDatabase();
            contactDatabase.UpdateContact(id, firstName, lastName, email, phnNum);
        }

        // DELETE api/Contact/5
        [System.Web.Http.HttpDelete()]
        public void Delete(int id)
        {
            ContactDatabase contactDatabase = new ContactDatabase();
           bool IsDeleted = contactDatabase.DeleteContact(id);
            if (IsDeleted)
                Console.WriteLine("Contact Deleted");
            else
                Console.WriteLine("Contact cant be deleted");
        }
    }
}
