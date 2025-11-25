using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using HRApp; // Основной namespace
using HRApp.Services;
using HRApp.Models;

namespace Test_Kadri
{
    [TestClass]
    public class EmployeeServiceTest
    {
        [TestMethod]
        public void RegisterEmployee_ValidData_ShouldReturnTrue()
        {
            // Arrange
            var service = new EmployeeService();
            string errorMessage;

            // Act
            bool result = service.RegisterEmployee(
                "Иванов",           // Фамилия
                "Иван",             // Имя
                "Иванович",         // Отчество
                new DateTime(1985, 5, 15),
                "Менеджер",
                1,
                DateTime.Now.AddDays(-365),
                "Полная занятость",
                out errorMessage
            );

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual("", errorMessage);
        }

        [TestMethod]
        public void RegisterEmployee_Under18_ShouldReturnError()
        {
            // Arrange
            var service = new EmployeeService();
            string errorMessage;

            // Act
            bool result = service.RegisterEmployee(
                "Молодой",
                "Сотрудник",
                "", // Пустое отчество
                DateTime.Now.AddYears(-17), // 17 лет
                "Стажер",
                1,
                DateTime.Now.AddDays(-10),
                "Стажировка",
                out errorMessage
            );

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual("Сотрудник должен быть старше 18 лет.", errorMessage);
        }

        [TestMethod]
        public void DeleteEmployee_ExistingEmployee_ShouldReturnTrue()
        {
            // Arrange
            var service = new EmployeeService();
            string errorMessage;

            // Сначала регистрируем сотрудника
            service.RegisterEmployee(
                "Тестовый",
                "Сотрудник",
                "Для удаления",
                new DateTime(1990, 1, 1),
                "Тестовая должность",
                1,
                DateTime.Now.AddDays(-100),
                "Полная занятость",
                out errorMessage
            );

            // Находим ID зарегистрированного сотрудника
            var allEmployees = service.GetAllEmployees();
            var testEmployee = allEmployees.First(e => e.LastName == "Тестовый");
            int employeeId = testEmployee.Id;

            // Act
            bool deleteResult = service.DeleteEmployee(employeeId, out errorMessage);

            // Assert
            Assert.IsTrue(deleteResult);
            Assert.AreEqual("", errorMessage);
        }

        [TestMethod]
        public void DeleteEmployee_NonExistentId_ShouldReturnError()
        {
            // Arrange
            var service = new EmployeeService();
            string errorMessage;

            // Act
            bool result = service.DeleteEmployee(9999, out errorMessage);

            // Assert
            Assert.IsFalse(result);
            Assert.AreEqual("Сотрудник не найден.", errorMessage);
        }
    }

    [TestClass]
    public class EmployeeModelTest
    {
        [TestMethod]
        public void Employee_FullName_ShouldConcatenateCorrectly()
        {
            // Arrange & Act
            var employee = new Employee
            {
                LastName = "Иванов",
                FirstName = "Иван",
                MiddleName = "Иванович"
            };

            // Assert
            Assert.AreEqual("Иванов Иван Иванович", employee.FullName);
        }

        [TestMethod]
        public void EmployeeRegistrationData_ShouldInitializeCorrectly()
        {
            // Arrange & Act
            var registrationData = new EmployeeRegistrationData
            {
                LastName = "Сидоров",
                FirstName = "Петр",
                MiddleName = "Козьмич",
                BirthDate = new DateTime(1978, 11, 10),
                Position = "Бухгалтер",
                DepartmentId = 3,
                HireDate = new DateTime(2021, 11, 10),
                EmploymentType = "Частичная"
            };

            // Assert
            Assert.AreEqual("Сидоров", registrationData.LastName);
            Assert.AreEqual("Петр", registrationData.FirstName);
            Assert.AreEqual("Козьмич", registrationData.MiddleName);
        }
    }
}