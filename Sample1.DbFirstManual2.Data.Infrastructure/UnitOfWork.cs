using Sample1.DbFirstManual2.Data.Core.Interfaces;
using Sample1.DbFirstManual2.Data.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample1.DbFirstManual2.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Sample1DbContext Context;

        public UnitOfWork(Sample1DbContext context)
        {
            Context = context;
            Employees = new EmployeeRepository(Context);
        }
        public IEmployeeRepository Employees
        {
            get; private set;
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
