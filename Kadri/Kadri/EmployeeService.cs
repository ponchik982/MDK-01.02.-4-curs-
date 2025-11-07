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

        public List<Employee> GetAllEmployees()
        {
            try
            {
                // ВРЕМЕННО: возвращаем тестовые данные с EmploymentType
                return GetTestEmployees();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении списка сотрудников: {ex.Message}");
            }
        }

        // Временный метод с тестовыми данными, включая EmploymentType
        private List<Employee> GetTestEmployees()
        {
            return new List<Employee>
        {
        new Employee
            {
                Id = 1,
                FullName = "Иванов Иван Иванович",
                BirthDate = new DateTime(1985, 5, 15),
                Position = "Менеджер",
                DepartmentId = 1,
                HireDate = new DateTime(2020, 1, 10),
                EmploymentType = "Полная занятость"
            },
            new Employee
            {
                Id = 2,
                FullName = "Петрова Анна Сергеевна",
                BirthDate = new DateTime(1990, 8, 22),
                Position = "Разработчик",
                DepartmentId = 2,
                HireDate = new DateTime(2021, 3, 15),
                EmploymentType = "Полная занятость"
            },
            new Employee
            {
                Id = 3,
                FullName = "Сидоров Алексей Петрович",
                BirthDate = new DateTime(1988, 12, 5),
                Position = "Аналитик",
                DepartmentId = 1,
                HireDate = new DateTime(2019, 7, 20),
                EmploymentType = "Частичная занятость"
            },
            new Employee
            {
                Id = 4,
                FullName = "Козлова Мария Владимировна",
                BirthDate = new DateTime(1992, 3, 30),
                Position = "Стажер",
                DepartmentId = 3,
                HireDate = new DateTime(2023, 9, 1),
                EmploymentType = "Стажировка"
             }
        };
        }
    }
}