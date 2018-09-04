using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    class Employee
    {
        private String firstName; 

        public String FirstName { get { return firstName; } set { firstName = value; } }

        public String LastName { get; set; }

        public System.DateTime DOB { get; set; }

        public Guid EmployeeGuid { get; } = Guid.NewGuid();

        public String Username { get; set; }

        public String UserPassword { get; set; }

        public int Role { get; set; }
    }
}
