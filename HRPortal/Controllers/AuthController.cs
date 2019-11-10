using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;
using HRPortal.ViewModels;
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
        private readonly portaldbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private IConfiguration _configuration;

        public AuthController(portaldbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser>
            signInManager, IConfiguration configuration,RoleManager<IdentityRole> roleManager)

        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody]RegisterViewModel model)
        {
            model.role = "Employee";
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
<<<<<<< HEAD
            await _userManager.AddToRoleAsync(user,model.role);
=======
            await _userManager.AddToRoleAsync(user, "Employee");
            await _userManager.AddClaimAsync(user, new Claim("MyClaimType", "MyClaimValue"));
>>>>>>> d040df2a07e5ba7386c650da2433c0b874d0bcc4
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
            }
            return Ok(new { UserName = user.UserName });
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody]LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                IdentityOptions _options = new IdentityOptions();
                var claims = new List<Claim>{ new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    
            };             
                var roles = await _userManager.GetRolesAsync(user);
                AddRolestoClaims(claims, roles);            
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"]));
            var signinCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            int expiryInMinutes = Convert.ToInt32(_configuration["JWT:ExpiryInMinutes"]);
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Site"],
                audience: _configuration["JWT:Site"],
                expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                claims:claims,
                signingCredentials: signinCredentials
                );

            await _userManager.RemoveAuthenticationTokenAsync(user, "MyApp", "RefreshToken");
            var newRefreshToken = new JwtSecurityTokenHandler().WriteToken(token);
            await _userManager.SetAuthenticationTokenAsync(user, "MyApp", "RefreshToken", newRefreshToken);
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
            });
        
            }
            return Unauthorized();
        }

        private void AddRolestoClaims(List<Claim> claims, IEnumerable<string> roles)
        {
            foreach (var role in roles)
            {
                var roleclaim = new Claim(ClaimTypes.Role, role);
                claims.Add(roleclaim);
            }
        }
    }
}