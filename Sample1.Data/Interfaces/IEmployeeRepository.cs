using Sample1.Data.Domains;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample1.Data.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee emp);
        void Edit(Employee emp);
        void Remove(int id);
        IEnumerable GetEmployees();
        Employee FindById(int id);

    }
}
