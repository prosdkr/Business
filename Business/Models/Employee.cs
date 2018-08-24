using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    class Employee
    {
        public String FirstName { get; set; }

        public String LastName { get; set; }

        public System.DateTime DOB { get; set; }

        public Guid EmployeeGuid { get; } = Guid.NewGuid();



        public String Username { get; set; }

        public String UserPassword { get; set; }

    }
}
