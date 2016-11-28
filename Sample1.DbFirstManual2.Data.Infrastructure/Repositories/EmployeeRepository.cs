using Sample1.DbFirstManual2.Data.Core.Domains;
using Sample1.DbFirstManual2.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample1.DbFirstManual2.Data.Infrastructure.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(Sample1DbContext context) : base(context)
        {
        }
        public Sample1DbContext Sample1DbContext
        {
            get { return Context as Sample1DbContext; }
        }

        public IEnumerable<Employee> GetEmployeeByPage(int pageIndex, int pageSize=10)
        {
            return Sample1DbContext.Employees
               .OrderBy(c => c.FirstName)
               .Skip((pageIndex - 1) * pageSize)
               .Take(pageSize)
               .ToList();
        }
    }
}
