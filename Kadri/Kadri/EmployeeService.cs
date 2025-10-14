using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HRApp.Models;

namespace HRApp.Services
{
    public class EmployeeService
    {
        private readonly List<Employee> _employees = new List<Employee>();
        private int _nextId = 1;

        public (bool Success, string ErrorMessage) RegisterEmployee(EmployeeRegistrationData data)
        {
            // Проверка на null
            if (data == null)
                return (false, "Данные не переданы");

            // Проверка ФИО
            if (string.IsNullOrWhiteSpace(data.FullName) ||
                !Regex.IsMatch(data.FullName, @"^[А-Яа-яЁё]+\s[А-Яа-яЁё]+\s[А-Яа-яЁё]+$"))
                return (false, "Некорректное ФИО");

            // Проверка возраста (не младше 18 лет)
            var age = DateTime.Today.Year - data.BirthDate.Year;
            if (data.BirthDate.Date > DateTime.Today.AddYears(-age)) age--;

            if (data.BirthDate == default || age < 18)
                return (false, "Некорректная дата рождения (меньше 18 лет)");

            // Проверка должности
            if (string.IsNullOrWhiteSpace(data.Position))
                return (false, "Должность обязательна");

            // Проверка отдела
            if (data.DepartmentId <= 0)
                return (false, "Некорректный отдел");

            // Проверка даты приёма
            if (data.HireDate < data.BirthDate.AddYears(18) || data.HireDate > DateTime.Today)
                return (false, "Некорректная дата приёма на работу");

            // Проверка типа занятости
            if (string.IsNullOrWhiteSpace(data.EmploymentType))
                return (false, "Тип занятости обязателен");

            // Проверка дубликатов
            foreach (var emp in _employees)
            {
                if (emp.FullName == data.FullName && emp.BirthDate == data.BirthDate)
                    return (false, "Сотрудник уже зарегистрирован");
            }

            // Добавление нового сотрудника
            var newEmployee = new Employee
            {
                Id = _nextId++,
                FullName = data.FullName,
                BirthDate = data.BirthDate,
                Position = data.Position,
                DepartmentId = data.DepartmentId,
                HireDate = data.HireDate,
                EmploymentType = data.EmploymentType
            };

            _employees.Add(newEmployee);
            return (true, null);
        }
    }
}