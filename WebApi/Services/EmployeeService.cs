using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Get(int id);
        Task<IQueryable<Employee>> GetAll();
        Task Insert(Employee employee);
        Task Update(int id, Employee employee);
        Task Delete(int id);
        Task<bool> EmployeeExists(int id);
    }

    public class EmployeeService : IEmployeeService
    {
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmployeeExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> Get(int id)
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