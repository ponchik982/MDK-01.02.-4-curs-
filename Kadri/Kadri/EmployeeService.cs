using HRApp.Models;
using HRApp.Services;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HRApp
{
    // Сервис регистрации сотрудников
    public class EmployeeService
    {
        private List<Employee> employees = new List<Employee>();
        private int nextId = 1;

        public bool RegisterEmployee(string fullName, DateTime birthDate, string position, int departmentId, DateTime hireDate, string employmentType, out string errorMessage)
        {
            errorMessage = "";

            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(fullName))
            {
                errorMessage = "Введите ФИО.";
                return false;
            }

            // Проверка возраста
            int age = DateTime.Now.Year - birthDate.Year;
            if (birthDate > DateTime.Now.AddYears(-age)) age--;
            if (age < 18)
            {
                errorMessage = "Сотрудник должен быть старше 18 лет.";
                return false;
            }

            // Проверка должности
            if (string.IsNullOrWhiteSpace(position))
            {
                errorMessage = "Введите должность.";
                return false;
            }

            // Проверка отдела
            if (departmentId <= 0)
            {
                errorMessage = "Введите корректный ID отдела.";
                return false;
            }

            // Проверка даты приёма
            if (hireDate > DateTime.Now)
            {
                errorMessage = "Дата приёма не может быть в будущем.";
                return false;
            }

            // Проверка типа занятости
            if (string.IsNullOrWhiteSpace(employmentType))
            {
                errorMessage = "Введите тип занятости.";
                return false;
            }

            // Проверка дубликатов
            foreach (var emp in employees)
            {
                if (emp.FullName == fullName && emp.BirthDate == birthDate)
                {
                    errorMessage = "Такой сотрудник уже зарегистрирован.";
                    return false;
                }
            }

            // Добавляем сотрудника
            var newEmployee = new Employee
            {
                Id = nextId++,
                FullName = fullName,
                BirthDate = birthDate,
                Position = position,
                DepartmentId = departmentId,
                HireDate = hireDate,
                EmploymentType = employmentType
            };

            employees.Add(newEmployee);
            return true;
        }

        public List<Employee> GetAll()
        {
            return employees;
        }
    }
}