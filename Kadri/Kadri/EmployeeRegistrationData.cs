using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models
{
    public class EmployeeRegistrationData
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; } 
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public DateTime HireDate { get; set; }
        public string EmploymentType { get; set; }
    }
}