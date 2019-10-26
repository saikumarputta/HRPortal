using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;
using HRPortal.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HRPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PortaldbContext _portaldbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        public AuthController(PortaldbContext context, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _portaldbContext = context;
            _userManager = userManager;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterViewModel model)
        {
            var user = new IdentityUser {
                UserName = model.Email,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Employees");
            }
            return Ok(new {Username = user.UserName});
        }

        public async Task<IActionResult> LoginUser([FromBody]LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null & await _userManager.CheckPasswordAsync(user,model.Password))
            {
                var claim = new[] { new Claim(JwtRegisteredClaimNames.Sub,user.UserName) };
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
                var signingCredentials = new SigningCredentials(signingKey,SecurityAlgorithms.EcdsaSha256);
                var expiryinMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);
                var token = new JwtSecurityToken(
                    issuer:_configuration["Jwt:Site"],
                    audience:  _configuration["Jwt:Site"],
                    expires:DateTime.UtcNow.AddMinutes(expiryinMinutes),
                    signingCredentials: signingCredentials
                    );
                return Ok(new {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

    }
}