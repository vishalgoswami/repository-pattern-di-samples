using Sample1.DbFirstManual2.Data.Core.Domains;
using System.Collections.Generic;

namespace Sample1.DbFirstManual2.Data.Core.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeeByPage(int pageIndex, int pageSize);

    }
}
