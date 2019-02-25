using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public interface IEmployeeService
    {
        Task<Employee> Get(int id);
        Task<IQueryable<Employee>> GetAll();
        Task Insert(EmployeeViewModel employee);
        Task Update(int id, EmployeeViewModel employee);
        Task Delete(int id);
        Task<bool> EmployeeExists(int id);
    }
}