using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRPortal.Models;
using HRPortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeRepository;
        public EmployeeController(IEmployee employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetEmployees();
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            return _employeeRepository.GetById(id);
            // return "value";
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee employee)
        {
            _employeeRepository.UpdateEmployee(id, employee);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
        }
    }
}
