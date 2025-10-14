using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HRApp.Models;

namespace HRApp.Services
{
    public class EmployeeService
    {
        public (bool Success, string ErrorMessage, int? EmployeeId) RegisterEmployee(EmployeeRegistrationData data)
        {
            // Проверка корректности ФИО
            if (string.IsNullOrWhiteSpace(data.FullName) ||
                !Regex.IsMatch(data.FullName, @"^[А-Яа-яЁё]+\s[А-Яа-яЁё]+\s[А-Яа-яЁё]+$"))
            {
                return (false, "Некорректное ФИО", null);
            }

            // В реальном приложении здесь будет сохранение в БД
            return (true, null, 1);
        }
    }
}