using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserDBUtility.UserModels;

namespace IncomePlanner.Controllers.Authentication
{
    [AllowAnonymous]
    [Route("Api/User")]
    [ApiController]
    public class UserAuthenticateController : ControllerBase
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public UserAuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
        }
        #endregion

        #region Methods               
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            string strRegex = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{3,}$";
            Regex re = new Regex(strRegex);

            var userExists = await _userManager.FindByNameAsync(model.UserName);

            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists" });

            if (!re.IsMatch(model.Password))
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Please enter valid password" });

            if (model.Password != model.ConfirmPassword)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Password and coonfirm password are not matching" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = new Guid().ToString(),
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed" });
            else
            {
                var addRoleResult = await _userManager.AddToRoleAsync(user, "User");

                if (!addRoleResult.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Not able to add the role to user" });
            }
            
            return Ok(new Response { Status = "Success", Message = "User created successfully" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim("Id",Convert.ToString(user.Id))
                };
                foreach(var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:Secret"]));
                var token = new JwtSecurityToken(
                        issuer: _configuration["jwt:ValidIssuer"],
                        audience: _configuration["jwt:ValidAudience"],
                        expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["jwt:AccessTokenExpiration"])),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigninKey,SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return Unauthorized();
        }
        #endregion
    }
}
