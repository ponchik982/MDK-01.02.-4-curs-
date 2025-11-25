using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using HRApp.Services;
using HRApp.Models;
using HRApp.Repositories;

namespace Kadri.Tests.Services
{
    [TestClass]
    public class EmployeeCardServiceTests
    {
        private Mock<IEmployeeRepository> _mockEmployeeRepo;
        private Mock<IDepartmentRepository> _mockDepartmentRepo;
        private EmployeeCardService _employeeCardService;

        [TestInitialize]
        public void Setup()
        {
            _mockEmployeeRepo = new Mock<IEmployeeRepository>();
            _mockDepartmentRepo = new Mock<IDepartmentRepository>();
            _employeeCardService = new EmployeeCardService(_mockEmployeeRepo.Object, _mockDepartmentRepo.Object);
        }

        [TestMethod]
        public void GetEmployeeDetails_ValidEmployee_ReturnsEmployeeDetails()
        {
            // Arrange
            var employeeId = 1;
            var employee = new Employee
            {
                Id = employeeId,
                LastName = "Иванов",
                FirstName = "Иван",
                MiddleName = "Иванович",
                BirthDate = new DateTime(1990, 5, 15),
                Position = "Менеджер",
                DepartmentId = 1,
                HireDate = new DateTime(2020, 1, 10),
                EmploymentType = "Полная занятость",
                Email = "ivanov@company.com",
                Phone = "+79991234567",
                Address = "г. Москва"
            };

            var department = new Department { Id = 1, Name = "Отдел продаж" };

            _mockEmployeeRepo.Setup(r => r.GetById(employeeId)).Returns(employee);
            _mockDepartmentRepo.Setup(r => r.GetById(employee.DepartmentId)).Returns(department);

            // Act
            var result = _employeeCardService.GetEmployeeDetails(employeeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Иванов Иван Иванович", result.FullName);
            Assert.AreEqual(35, result.Age);
            Assert.AreEqual("Менеджер", result.Position);
            Assert.AreEqual("Отдел продаж", result.DepartmentName);
            Assert.AreEqual("ivanov@company.com", result.Email);
        }

        [TestMethod]
        public void GetEmployeeDetails_EmployeeNotFound_ReturnsNull()
        {
            // Arrange
            var employeeId = 999;
            _mockEmployeeRepo.Setup(r => r.GetById(employeeId)).Returns((Employee)null);

            // Act
            var result = _employeeCardService.GetEmployeeDetails(employeeId);

            // Assert
            Assert.IsNull(result);
        }
    }

    [TestClass]
    public class EmployeeCardCalculationTests
    {
        private EmployeeCardService _employeeCardService;

        [TestInitialize]
        public void Setup()
        {
            _employeeCardService = new EmployeeCardService(null, null);
        }

        [TestMethod]
        public void CalculateAge_BirthDateInPast_ReturnsCorrectAge()
        {
            // Arrange
            var birthDate = new DateTime(1990, 5, 15);
            var currentDate = new DateTime(2023, 12, 1);

            // Act
            var age = _employeeCardService.CalculateAge(birthDate, currentDate);

            // Assert
            Assert.AreEqual(33, age);
        }

        [TestMethod]
        public void CalculateWorkExperience_LongExperience_ReturnsYearsAndMonths()
        {
            // Arrange
            var hireDate = new DateTime(2018, 3, 15);
            var currentDate = new DateTime(2023, 12, 1);

            // Act
            var experience = _employeeCardService.CalculateWorkExperience(hireDate, currentDate);

            // Assert
            Assert.AreEqual("5 лет 8 месяцев", experience);
        }
        // Временные заглушки для компиляции тестов
        public class DepartmentService : IDepartmentRepository
        {
            public Department GetById(int id)
            {
                return new Department { Id = id, Name = $"Отдел {id}" };
            }
        }

        public class TestEmployeeRepository : IEmployeeRepository
        {
            public Employee GetById(int id) => null;
            public bool Exists(int id) => false;
            public bool HasActiveRecords(int id) => false;
            public DeleteResult DeleteEmployee(int id) => DeleteResult.NotFound;
        }
    }
}