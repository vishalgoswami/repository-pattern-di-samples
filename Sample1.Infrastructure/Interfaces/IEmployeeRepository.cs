using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample1.DBFirst.Data.Infrastructure;

namespace Sample1.DBFirst.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(emp emp);
        void Edit(emp emp);
        void Remove(int id);
        IEnumerable GetEmployees();
        emp FindById(int id);

    }
}
