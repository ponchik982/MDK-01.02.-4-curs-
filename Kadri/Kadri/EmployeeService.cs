using HRApp.Models;
using HRApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HRApp
{
    public class EmployeeService
    {
        private List<Employee> employees = new List<Employee>();
        private int nextId = 1;

        public bool RegisterEmployee(string lastName, string firstName, string middleName,
                                   DateTime birthDate, string position, int departmentId,
                                   DateTime hireDate, string employmentType, out string errorMessage)
        {
            errorMessage = "";

            // Проверка фамилии
            if (string.IsNullOrWhiteSpace(lastName))
            {
                errorMessage = "Введите фамилию.";
                return false;
            }

            // Проверка имени
            if (string.IsNullOrWhiteSpace(firstName))
            {
                errorMessage = "Введите имя.";
                return false;
            }

            // Отчество может быть пустым

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

            // Проверка дубликатов (по ФИО и дате рождения)
            foreach (var emp in employees)
            {
                if (emp.LastName == lastName && emp.FirstName == firstName &&
                    emp.MiddleName == middleName && emp.BirthDate == birthDate)
                {
                    errorMessage = "Такой сотрудник уже зарегистрирован.";
                    return false;
                }
            }

            // Добавляем сотрудника
            var newEmployee = new Employee
            {
                Id = nextId++,
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

        public List<Employee> GetAll()
        {
            return employees;
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return GetTestEmployees();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении списка сотрудников: {ex.Message}");
            }
        }

        // Обновляем тестовые данные с раздельными ФИО
        private List<Employee> GetTestEmployees()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    LastName = "Иванов",
                    FirstName = "Иван",
                    MiddleName = "Иванович",
                    BirthDate = new DateTime(1985, 5, 15),
                    Position = "Менеджер",
                    DepartmentId = 1,
                    HireDate = new DateTime(2020, 1, 10),
                    EmploymentType = "Полная занятость"
                },
                new Employee
                {
                    Id = 2,
                    LastName = "Петрова",
                    FirstName = "Анна",
                    MiddleName = "Сергеевна",
                    BirthDate = new DateTime(1990, 8, 22),
                    Position = "Разработчик",
                    DepartmentId = 2,
                    HireDate = new DateTime(2021, 3, 15),
                    EmploymentType = "Полная занятость"
                },
                new Employee
                {
                    Id = 3,
                    LastName = "Сидоров",
                    FirstName = "Алексей",
                    MiddleName = "Петрович",
                    BirthDate = new DateTime(1988, 12, 5),
                    Position = "Аналитик",
                    DepartmentId = 1,
                    HireDate = new DateTime(2019, 7, 20),
                    EmploymentType = "Частичная занятость"
                },
                new Employee
                {
                    Id = 4,
                    LastName = "Козлова",
                    FirstName = "Мария",
                    MiddleName = "Владимировна",
                    BirthDate = new DateTime(1992, 3, 30),
                    Position = "Стажер",
                    DepartmentId = 3,
                    HireDate = new DateTime(2023, 9, 1),
                    EmploymentType = "Стажировка"
                },
                new Employee
                {
                    Id = 5,
                    LastName = "Смирнов",
                    FirstName = "Дмитрий",
                    MiddleName = "", // Пустое отчество
                    BirthDate = new DateTime(1987, 6, 12),
                    Position = "Тестировщик",
                    DepartmentId = 2,
                    HireDate = new DateTime(2022, 5, 20),
                    EmploymentType = "Полная занятость"
                }
            };
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

        public Employee GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}