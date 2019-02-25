using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmployeeExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Employee>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
