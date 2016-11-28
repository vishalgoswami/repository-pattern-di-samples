using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataImpl3Interfaces = Sample1.DbFirstManual2.Data.Core.Interfaces;
using DataImpl3Repositories = Sample1.DbFirstManual2.Data.Infrastructure.Repositories;
using DataImpl3Domains = Sample1.DbFirstManual2.Data.Core.Domains;
using DataImpl3Infratructure = Sample1.DbFirstManual2.Data.Infrastructure;
using System.Collections.Generic;

namespace Sample1.Tests.Controllers
{
    [TestClass]
    public class EmployeeRepositoryImpl3Test
    {
        DataImpl3Interfaces.IEmployeeRepository empRepo;
        [TestInitialize]
        public void TestSetup()
        {
            empRepo = new DataImpl3Repositories.EmployeeRepository( new DataImpl3Infratructure.Sample1DbContext());
        }
        [TestMethod]
        public void AddEmployee()
        {
            bool actualResult = true;
            try
            {
                empRepo.Add(new DataImpl3Domains.Employee
                {
                    FirstName = "sssssss",
                    LastName = "User"
                });
                empRepo.Save();
            }
            catch (Exception ex)
            {
                actualResult = false;
            }
            // Assert
            Assert.AreEqual(true, actualResult);
        }

        [TestMethod]
        public void AddEmployeeUsingUnitOfWork()
        {
            using (var unitOfWork = new DataImpl3Infratructure.UnitOfWork(new DataImpl3Infratructure.Sample1DbContext()))
            {


                // Example3
                unitOfWork.Employees.Add(new DataImpl3Domains.Employee {
                     FirstName = "gggggg",
                     LastName = "User"
                });
                var emp = unitOfWork.Employees.Find(q => q.FirstName.Equals("sssssss")).FirstOrDefault();

                if (emp != null)
                    unitOfWork.Employees.Remove(emp);
                unitOfWork.Complete();
            }
        }

        

      
        [TestMethod]
        public void AddEmployeeWithLongFirstName()
        {
            bool actualResult = true;
            try
            {
                empRepo.Add(new DataImpl3Domains.Employee
                {
                    FirstName = "012345678911",
                    LastName = "User"
                });
                empRepo.Save();
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
