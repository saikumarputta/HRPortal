using System.Collections.Generic;
using HRPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HRPortal.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin,Employee")]
    public class ValuesController : ControllerBase
    {
        private readonly portaldbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ValuesController(portaldbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> 
            signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
