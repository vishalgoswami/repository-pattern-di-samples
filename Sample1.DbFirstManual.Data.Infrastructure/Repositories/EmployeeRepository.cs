using System.Linq;
using System.Collections;
using Sample1.DbFirstManual.Data.Core.Interfaces;
using Sample1.DbFirstManual.Data.Core.Domains;

namespace Sample1.DbFirstManual.Data.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        Sample1DbContext context = new Sample1DbContext();
        public void Add(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
        }

        public void Edit(Employee emp)
        {
            context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
        }

        public Employee FindById(int id)
        {
            var result = (from r in context.Employees where r.ID == id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable GetEmployees()
        {
            return context.Employees;
        }

        public void Remove(int id)
        {
            Employee emp = context.Employees.Find(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
        }
    }
}
