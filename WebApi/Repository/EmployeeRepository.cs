using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public async Task Delete(int id)
        {
            var sql = "DELETE FROM Employee WHERE id = @id";
            var parameter = new SqlParameter("@id", id);
            await ExecuteNonQueryAsync(sql, parameter);
        }

        public async Task<bool> EmployeeExists(int id)
        {
            var sql = "SELECT TOP 1 ID FROM Employee";
            var items = await ExecuteNonQueryAsync(sql);
            return items > 0;
        }

        public async Task<Employee> Get(int id)
        {
            var sql = "SELECT * FROM Employee WHERE id = @id";
            var parameter = new SqlParameter("@id", id);
            var employees = await ExecuteReaderAsync(sql, parameter);
            return employees.FirstOrDefault();
        }

        public async Task<IQueryable<Employee>> GetAll()
        {
            var sql = "SELECT * FROM Employee";
            return await ExecuteReaderAsync(sql);
        }

        public async Task Insert(Employee employee)
        {
            var sql = @"INSERT INTO Employee (  Id,
                                                CompanyId,
                                                CreatedOn,
                                                DeletedOn,
                                                Email,
                                                Fax,
                                                Name,
                                                LastLogin,
                                                Password,
                                                PortalId,
                                                RoleId,
                                                StatusId,
                                                Telephone,
                                                UpdatedOn,
                                                Username)
                                        VALUES (@Id,
                                                @CompanyId,
                                                @CreatedOn,
                                                @DeletedOn,
                                                @Email,
                                                @Fax,
                                                @Name,
                                                @LastLogin,
                                                @Password,
                                                @PortalId,
                                                @RoleId,
                                                @StatusId,
                                                @Telephone,
                                                @UpdatedOn,
                                                @Username)";
            var parameters = await GetInsertParameters(employee);

            await ExecuteNonQueryAsync(sql, parameters);
        }

        public async Task Update(int id, Employee entity)
        {
            var employee = Get(id);
            if (employee == null)
                throw new KeyNotFoundException();
            var sql = @"UPDATE Employee
                        SET CompanyId = @CompanyId,
                            CreatedOn = @CreatedOn,
                            DeletedOn = @DeletedOn,
                            Email =     @Email,
                            Fax =       @Fax,
                            Name =      @Name,
                            LastLogin = @LastLogin,
                            Password =  @Password,
                            PortalId =  @PortalId,
                            RoleId =    @RoleId,
                            StatusId =  @StatusId,
                            Telephone = @Telephone,
                            UpdatedOn =  @UpdatedOn,
                            Username =  @Username
                        WHERE ID = @id";
            var parameters = SetParameters(id, entity);
            await ExecuteNonQueryAsync(sql, parameters);
        }

        protected override Employee SetItem(SqlDataReader reader)
        {
            Employee employee = new Employee
            {
                Id = GetInt(reader, "Id"),
                CompanyId = GetInt(reader, "CompanyId"),
                CreatedOn = GetDate(reader, "CreatedOn"),
                DeletedOn = GetDate(reader, "DeletedOn"),
                Email = reader["Email"].ToString(),
                Fax = reader["Fax"].ToString(),
                Name = reader["Name"].ToString(),
                LastLogin = GetDate(reader, "LastLogin"),
                Password = reader["Password"].ToString(),
                PortalId = GetInt(reader, "PortalId"),
                RoleId = GetInt(reader, "RoleId"),
                StatusId = GetInt(reader, "StatusId"),
                Telephone = reader["Telephone"].ToString(),
                UpdatedOn = GetDate(reader, "UpdatedOn"),
                Username = reader["Username"].ToString()
            };
            return employee;
        }

        async Task<List<SqlParameter>> GetInsertParameters(Employee entity)
        {
            int newId = await SimulateAutoincrement();
            //
            var parameters = SetParameters(newId, entity);
            return parameters;
        }

        async Task<int> SimulateAutoincrement()
        {
            var allItems = await GetAll();
            int newId = 1;
            if (allItems.Any())
            {
                newId = allItems.Max(x => x.Id) + 1;
            }

            return newId;
        }

        List<SqlParameter> SetParameters(int id, Employee entity)
        {
            var parameters = new List<SqlParameter>
            {
                SetParameter("CompanyId", entity.CompanyId),
                SetParameter("DeletedOn", entity.DeletedOn),
                SetParameter("CreatedOn", entity.CreatedOn),
                SetParameter("Email", entity.Email),
                SetParameter("Fax", entity.Fax),
                SetParameter("Name", entity.Name),
                SetParameter("LastLogin", entity.LastLogin),
                SetParameter("Password", entity.Password),
                SetParameter("PortalId", entity.PortalId),
                SetParameter("RoleId", entity.RoleId),
                SetParameter("StatusId", entity.StatusId),
                SetParameter("Telephone", entity.Telephone),
                SetParameter("UpdatedOn", entity.UpdatedOn),
                SetParameter("Username", entity.Username),
                SetParameter("Id",id)
            };
            return parameters;
        }
    }
}
