using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserDBUtility.UserModels;

namespace IncomePlanner.Controllers.Authentication
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("Api/Admin")]
    public class AdminAuthenticateController : ControllerBase
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public AdminAuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
        }
        #endregion

        #region Methods               
        [HttpPost]
        [Route("UserRoleAssign")]
        public async Task<IActionResult> UserRoleAssign([FromBody] UserRoleModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user!=null && !await _userManager.IsInRoleAsync(user, model.RoleName))
            {
                var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                if(!result.Succeeded)
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Not able to add the role to user" });

                return Ok(new Response { Status = "Success", Message = "Role has been added to the user successfully" });
            }

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already have the role" });
        }

        [HttpPost]
        [Route("CreateRoles")]
        public async Task<IActionResult> CreateRoles([FromBody] RolesModel model)
        {
            if (!await _roleManager.RoleExistsAsync(model.RoleName))
            {
                await _roleManager.CreateAsync(new ApplicationRole { Name = model.RoleName });
                return Ok(new Response { Status = "Success", Message = "Role created successfully" });
            }
                
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Role already exists" });
        }
        #endregion
    }
}
