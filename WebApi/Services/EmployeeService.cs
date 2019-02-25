using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repository;

namespace WebApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepository _repository;

        public EmployeeService()
        {
            _repository = new EmployeeRepository();
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<bool> EmployeeExists(int id)
        {
            return await _repository.EmployeeExists(id);
        }

        public async Task<Employee> Get(int id)
        {
            return await _repository.Get();
        }

        public async Task<IQueryable<Employee>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Insert(Employee employee)
        {
            await _repository.Insert(employee);
        }

        public async Task Update(int id, Employee employee)
        {
            await _repository.Update(id, employee);
        }
    }
}