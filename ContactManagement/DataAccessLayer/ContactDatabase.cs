using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ContactDatabase : IContactDatabase
    {
        public ContactDatabase()
        {
            Contact con = new Contact();
        }
        public List<Contact> GetAllContacts()
        {
            try
            {
                using (ContactManagementEntities context = new ContactManagementEntities())
                {
                    var contactList = (from c in context.Contacts.ToList()
                                       select new Contact
                                       {
                                           Id =c.Id,
                                           FirstName = c.FirstName,
                                           LastName = c.LastName,
                                           Email = c.Email,
                                           PhoneNumber = c.PhoneNumber,
                                           Status = c.Status
                                       }).ToList();

                    return contactList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contact GetContactById(int id)
        {
            using (ContactManagementEntities context = new ContactManagementEntities())
            {
                var contactId = context.Contacts.Where(con => con.Id == id).ToList();
                if (contactId.Count > 0)
                {
                    var contact = (from c in contactId
                                   select new Contact
                                   {
                                       Id = c.Id,
                                       FirstName = c.FirstName,
                                       LastName = c.LastName,
                                       Email = c.Email,
                                       PhoneNumber = c.PhoneNumber,
                                       Status = c.Status
                                   }).FirstOrDefault();
                    return contact;
                }
                return new Contact();
            }
        }

        public Contact SaveContact(string firstName, string lastName, string email, int phnNum)
        {
            try
            {
                using (var context = new ContactManagementEntities())
                {
                    var contact = new Contact();
                    {
                        contact.FirstName = firstName;
                        contact.LastName = lastName;
                        contact.Email = email;
                        contact.PhoneNumber = phnNum;
                        contact.Status = true;
                    };
                    context.Contacts.Add(contact);
                    context.SaveChanges();
                }
                return new Contact();
            }
            catch
            {
                throw;
            }
        }

        public bool UpdateContact(int id, string firstName, string lastName, string email, int phnNum)
        {
            try
            {
                using (var context = new ContactManagementEntities())
                {
                    var contactIdExists = context.Contacts.Where(con => con.Id == id).FirstOrDefault();
                    {
                        var contact = new Contact();
                        {
                            contact.FirstName = firstName;
                            contact.LastName = lastName;
                            contact.Email = email;
                            contact.PhoneNumber = phnNum;
                        };
                        context.SaveChanges();
                    }                   
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteContact(int id)
        {
            using (var context = new ContactManagementEntities())
            {
                var contactIdExists = context.Contacts.Where(con => con.Id == id).FirstOrDefault();
                if (contactIdExists != null && contactIdExists.Id == id)
                {
                    context.Contacts.Remove(contactIdExists);
                    context.SaveChanges();

                    return true;
                }
                else
                    return false;
            }
        }
        
    }
}
