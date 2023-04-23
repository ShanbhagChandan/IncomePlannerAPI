using BusinessLayer.Salary;
using IncomePlannerDB.IncomePlannerDbService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Salary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncomePlanner.Controllers.Salary
{
    [Authorize(Roles = "Admin,User")]
    [Route("Api/Salary")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private SalaryBusinessLayer salaryBusinessLayer;

        public SalaryController(IncomePlannerDbContext incomePlannerDbContext)
        {
            salaryBusinessLayer = new SalaryBusinessLayer(incomePlannerDbContext);
        }

        [HttpGet]
        [Route("GetSalary")]
        public UsersSalary GetSalary(int year)
        {
            int userId = 0;
            if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
            {
                userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
            }

            return salaryBusinessLayer.GetSalary(userId, year);
        }

        [HttpGet]
        [Route("GetInvestments")]
        public UsersInvestments GetInvestments(int year)
        {
            int userId = 0;
            if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
            {
                userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
            }

            return salaryBusinessLayer.GetInvestments(userId, year);
        }

        [HttpPost]
        [Route("PostSalary")]
        public int PostSalary(UsersSalary usersSalary)
        {
            int userId = 0;
            if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
            {
                userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
            }

            return salaryBusinessLayer.PostSalary(userId, usersSalary);
        }

        [HttpPost]
        [Route("PostInvestments")]
        public int PostInvestments(UsersInvestments usersInvestments)
        {
            int userId = 0;
            if (HttpContext.User.Claims.Where(x => x.Type == "Id").Any())
            {
                userId = int.Parse(HttpContext.User.Claims.Where(x => x.Type == "Id").FirstOrDefault()?.Value);
            }

            return salaryBusinessLayer.PostInvestments(userId, usersInvestments);
        }
    }
}
