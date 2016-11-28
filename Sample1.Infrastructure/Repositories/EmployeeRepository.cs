using System.Linq;
using System.Collections;

using Sample1.DBFirst.Data.Infrastructure;
using Sample1.DBFirst.Data.Interfaces;

namespace Sample1.DBFirst.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        Sample1DbContext context = new Sample1DbContext();
        public void Add(emp emp)
        {
            context.emps.Add(emp);
            context.SaveChanges();
        }

        public void Edit(emp emp)
        {
            context.Entry(emp).State = System.Data.Entity.EntityState.Modified;
        }

        public emp FindById(int id)
        {
            var result = (from r in context.emps where r.ID == id select r).FirstOrDefault();
            return result;
        }

        public IEnumerable GetEmployees()
        {
            return context.emps;
        }

        public void Remove(int id)
        {
            emp emp = context.emps.Find(id);
            context.emps.Remove(emp);
            context.SaveChanges();
        }
    }
}
