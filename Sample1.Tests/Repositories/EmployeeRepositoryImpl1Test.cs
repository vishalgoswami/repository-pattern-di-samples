using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataImpl1Interfaces = Sample1.DBFirst.Data.Interfaces;
using DataImpl1Repositories = Sample1.DBFirst.Data.Repositories;
using DataImpl1Infratructure = Sample1.DBFirst.Data.Infrastructure;


namespace Sample1.Tests.Controllers
{
    [TestClass]
    public class EmployeeRepositoryImpl1Test
    {
        DataImpl1Interfaces.IEmployeeRepository empRepo;
        [TestInitialize]
        public void TestSetup()
        {
            empRepo = new DataImpl1Repositories.EmployeeRepository();
        }

       

        [TestMethod]
        public void AddEmployee()
        {
            bool actualResult = true;
            try
            {
                empRepo.Add(new DataImpl1Infratructure.emp
                {
                    FirstName = "Xyz",
                    LastName = "User"
                });
            }
            catch (Exception ex)
            {
                actualResult = false;
            }
            // Assert
            Assert.AreEqual(true, actualResult);
        }

        [TestMethod]
        public void FindEmployee()
        {
            var emp = empRepo.FindById(97);
            Assert.IsNotNull(emp);
            Assert.AreEqual(97, emp.ID);
        }
        [TestMethod]
        public void AddEmployeeWithLongFirstName()
        {
            bool actualResult = true;
            try
            {
                empRepo.Add(new DataImpl1Infratructure.emp
                {
                    FirstName = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                    LastName = "User"
                });
            }
            catch (Exception ex)
            {
                actualResult = false;
            }
            // Assert
            Assert.AreEqual(false, actualResult);
        }

    }
}
