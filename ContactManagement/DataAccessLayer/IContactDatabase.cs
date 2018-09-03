using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public interface IContactDatabase
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);

        Contact SaveContact(string firstName, string lastName, string email, int phnNum);

        bool UpdateContact(int id, string firstName, string lastName, string email, int phnNum);

        bool DeleteContact(int id);

    }
}
