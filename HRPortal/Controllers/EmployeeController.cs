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
        private readonly EmployeeRepository _employeeRepository;
        public EmployeeController(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetEmployees();
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
