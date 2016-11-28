using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Sample1.DbFirstManual.Data.Core.Interfaces;
using Sample1.DbFirstManual.Data.Infrastructure.Repositories;

namespace Sample1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}