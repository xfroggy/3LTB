using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3LTB.Helpers
{
    public class _3LTBIdentityUser : IdentityUser
    {
        [ProtectedPersonalData]
        public virtual string SeniorityNumber { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string EmployeeID { get; set; }
        public virtual string Base { get; set; }

    }
}
