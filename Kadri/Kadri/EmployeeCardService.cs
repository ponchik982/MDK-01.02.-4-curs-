using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRApp.Repositories;
using HRApp.Models;

namespace HRApp.Services
{
    public class EmployeeCardService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeCardService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public EmployeeDetails GetEmployeeDetails(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null) return null;

            var department = _departmentRepository.GetById(employee.DepartmentId);

            var details = new EmployeeDetails
            {
                Id = employee.Id,
                LastName = employee.LastName,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                BirthDate = employee.BirthDate,
                Age = CalculateAge(employee.BirthDate),
                Position = employee.Position,
                DepartmentId = employee.DepartmentId,
                DepartmentName = department?.Name ?? "Не указан",
                HireDate = employee.HireDate,
                WorkExperience = CalculateWorkExperience(employee.HireDate),
                EmploymentType = employee.EmploymentType,
                Email = employee.Email,
                Phone = employee.Phone,
                Address = employee.Address
            };

            return details;
        }

        public int CalculateAge(DateTime birthDate)
        {
            return CalculateAge(birthDate, DateTime.Now);
        }

        public string CalculateWorkExperience(DateTime hireDate)
        {
            return CalculateWorkExperience(hireDate, DateTime.Now);
        }

        // Методы для тестирования с фиксированной датой
        public int CalculateAge(DateTime birthDate, DateTime currentDate)
        {
            var age = currentDate.Year - birthDate.Year;
            if (birthDate.Date > currentDate.AddYears(-age)) age--;
            return age;
        }

        public string CalculateWorkExperience(DateTime hireDate, DateTime currentDate)
        {
            var months = (currentDate.Year - hireDate.Year) * 12 + currentDate.Month - hireDate.Month;
            if (currentDate.Day < hireDate.Day) months--;

            if (months < 1) return "Менее месяца";

            var years = months / 12;
            months = months % 12;

            if (years == 0) return $"{months} месяцев";
            if (months == 0) return $"{years} лет";
            return $"{years} лет {months} месяцев";
        }
    }
}
