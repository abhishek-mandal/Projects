using System;
using System.Collections.Generic;

namespace ContactManagement.Models
{
    // Models returned by AccountController actions.

    public class ContactDetails
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int? PhoneNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
