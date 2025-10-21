using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HRApp.Services;
using HRApp.Models;


namespace Test_Kadri
{
    [TestClass]
    public class EmployeeServiceTests
    {
        [TestMethod]
        public void РегистрацияСотрудника_СкорректнымиДанными_ВозвращаетУспех()
        {
            // Подготовка
            var service = new EmployeeService();
            var data = new EmployeeRegistrationData
            {
                FullName = "Иванов Сергей Петрович",
                BirthDate = new DateTime(1985, 4, 15),
                Position = "Оператор",
                DepartmentId = 2,
                HireDate = new DateTime(2023, 9, 1),
                EmploymentType = "штатный"
            };

            // Действие
            var result = service.RegisterEmployee(data);

            // Проверка
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.EmployeeId);
        }

        [TestMethod]
        public void РегистрацияСотрудника_СНекорректнымФИО_ВозвращаетОшибку()
        {
            // Подготовка
            var service = new EmployeeService();
            var data = new EmployeeRegistrationData
            {
                FullName = "Иванов@ Сергей", // некорректное ФИО
                BirthDate = new DateTime(1985, 4, 15),
                Position = "Оператор",
                DepartmentId = 2,
                HireDate = new DateTime(2023, 9, 1),
                EmploymentType = "штатный"
            };

            // Действие
            var result = service.RegisterEmployee(data);

            // Проверка
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Некорректное ФИО", result.ErrorMessage);
        }
    }
}