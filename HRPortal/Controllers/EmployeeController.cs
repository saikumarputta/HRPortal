using HRPortal.Models;
using HRPortal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HRPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employeeRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public EmployeeController(IEmployee employeeRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employee
        [Authorize(Roles = "Employee")]
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
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
