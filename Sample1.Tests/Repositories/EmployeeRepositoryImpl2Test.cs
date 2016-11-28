using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataImpl2Interfaces = Sample1.DbFirstManual.Data.Core.Interfaces;
using DataImpl2Repositories = Sample1.DbFirstManual.Data.Infrastructure.Repositories;
using DataImpl2Domains = Sample1.DbFirstManual.Data.Core.Domains;


namespace Sample1.Tests.Controllers
{
    [TestClass]
    public class EmployeeRepositoryImpl2Test
    {
        DataImpl2Interfaces.IEmployeeRepository empRepo;
        [TestInitialize]
        public void TestSetup()
        {
            empRepo = new DataImpl2Repositories.EmployeeRepository();
        }

       

        [TestMethod]
        public void AddEmployee()
        {
            bool actualResult = true;
            try
            {
                empRepo.Add(new DataImpl2Domains.Employee
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
                empRepo.Add(new DataImpl2Domains.Employee
                {
                    FirstName = "012345678911",
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
