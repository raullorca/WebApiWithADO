using System;
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
            return await _repository.Get(id);
        }

        public async Task<IQueryable<Employee>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task Insert(EmployeeViewModel model)
        {
            var employee = Map(model);
            await _repository.Insert(employee);
        }

        public async Task Update(int id, EmployeeViewModel model)
        {
            var employee = Map(model);
            await _repository.Update(id, employee);
        }
        Employee Map(EmployeeViewModel entity)
        {
            Employee employee = new Employee
            {
                Id = entity.Id,
                CompanyId = entity.CompanyId,
                CreatedOn = ToDateTime(entity.CreatedOn),
                DeletedOn = ToDateTime(entity.DeletedOn),
                Email = entity.Email,
                Fax = entity.Fax,
                LastLogin = ToDateTime(entity.LastLogin),
                Name = entity.Name,
                Password = entity.Password,
                PortalId = entity.PortalId,
                RoleId = entity.RoleId,
                StatusId = entity.StatusId,
                Telephone = entity.Telephone,
                UpdatedOn = ToDateTime(entity.UpdatedOn),
                Username = entity.Username
            };

            return employee;
        }

        // Transform date 

        /// <summary>
        /// I have detected an error when transforming the hours from the defined file, since the
        /// date was not executed correctly I have chosen to carry out the process manually
        /// </summary>
        public DateTime ToDateTime(string value)
        {
            if (value == null)
            {
                return DateTime.MinValue;
            }
            //return DateTime.ParseExact(value, "yyyy-MM-dd hh:mm:ss", null);

            var dateAndTime = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            DateTime time = new DateTime(0);
            if (dateAndTime.Count() == 2)
            {
                time = Convert.ToDateTime(dateAndTime[1]);
            }
            var onlyDate = dateAndTime[0].Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            var year = int.Parse(onlyDate[0]);
            var month = int.Parse(onlyDate[1]);
            // remove special char 8203 
            var dayString = onlyDate[2].Substring(0, 2);

            var day = int.Parse(dayString);

            return new DateTime(year, month, day, time.Hour, time.Minute, time.Second);
        }
    }
}