using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface IEmployeeRepository
    {
        Task<Employee> Get();
        Task<IQueryable<Employee>> GetAll();
        Task<bool> EmployeeExists(int id);
        Task Insert(Employee employee);
        Task Update(int id, Employee employee);
        Task Delete(int id);
    }
}
