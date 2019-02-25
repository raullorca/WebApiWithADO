using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<bool> EmployeeExists(int id);
    }
}
