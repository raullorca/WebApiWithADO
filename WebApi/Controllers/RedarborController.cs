﻿using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    public class RedarborController : ApiController
    {
        readonly IEmployeeService _service;

        public RedarborController()
        {
            _service = new EmployeeService();
        }

        [HttpGet]
        public async Task<IQueryable<Employee>> Get()
        {
            return await _service.GetAll();
        }


        [HttpGet]
        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var employee = await _service.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(int id, EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.Update(id, employee);
            }
            catch
            {
                if (!(await _service.EmployeeExists(id)))
                {
                    return NotFound();
                }
                return BadRequest();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> Post(EmployeeViewModel employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _service.Insert(employee);
            }
            catch
            {
                if (await _service.EmployeeExists(employee.Id))
                {
                    return Conflict();
                }
                throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        [ResponseType(typeof(Employee))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var employee = await _service.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            try
            {
                await _service.Delete(id);
                return Ok(employee);
            }
            catch
            {
                return BadRequest();
            }


        }

    }
}
