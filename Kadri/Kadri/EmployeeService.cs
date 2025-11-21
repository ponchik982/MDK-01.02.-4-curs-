using HRApp.Models;
using HRApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRApp
{
    public class EmployeeService
    {
        private List<Employee> employees;

        public EmployeeService()
        {
            // Инициализируем один общий список
            employees = new List<Employee>
            {
                new Employee { Id = 1, LastName = "Иванов", FirstName = "Иван", MiddleName = "Иванович", BirthDate = new DateTime(1985, 5, 15), Position = "Менеджер", DepartmentId = 1, HireDate = new DateTime(2020, 1, 10), EmploymentType = "Полная занятость" },
                new Employee { Id = 2, LastName = "Петрова", FirstName = "Анна", MiddleName = "Сергеевна", BirthDate = new DateTime(1990, 8, 22), Position = "Разработчик", DepartmentId = 2, HireDate = new DateTime(2021, 3, 15), EmploymentType = "Полная занятость" },
                new Employee { Id = 3, LastName = "Сидоров", FirstName = "Алексей", MiddleName = "Петрович", BirthDate = new DateTime(1988, 12, 5), Position = "Аналитик", DepartmentId = 1, HireDate = new DateTime(2019, 7, 20), EmploymentType = "Частичная занятость" }
            };
        }

        public bool RegisterEmployee(string lastName, string firstName, string middleName,
                                   DateTime birthDate, string position, int departmentId,
                                   DateTime hireDate, string employmentType, out string errorMessage)
        {
            errorMessage = "";

            // ... валидации ...

            // Добавляем в ОБЩИЙ список
            var newEmployee = new Employee
            {
                Id = employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1,
                LastName = lastName.Trim(),
                FirstName = firstName.Trim(),
                MiddleName = middleName?.Trim(),
                BirthDate = birthDate,
                Position = position.Trim(),
                DepartmentId = departmentId,
                HireDate = hireDate,
                EmploymentType = employmentType.Trim()
            };

            employees.Add(newEmployee);
            return true;
        }

        public List<Employee> GetAllEmployees()
        {
            return employees; // Возвращаем ОБЩИЙ список
        }

        public bool DeleteEmployee(int id, out string errorMessage)
        {
            errorMessage = "";

            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                errorMessage = "Сотрудник не найден.";
                return false;
            }

            employees.Remove(employee);
            return true;
        }
    }
}