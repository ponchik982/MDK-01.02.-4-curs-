﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Services
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public DateTime HireDate { get; set; }
        public string EmploymentType { get; set; }
    }
}
