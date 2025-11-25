using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Models
{
    public class EmployeeDetails
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName => $"{LastName} {FirstName} {MiddleName}".Trim();
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime HireDate { get; set; }
        public string WorkExperience { get; set; }
        public string EmploymentType { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
