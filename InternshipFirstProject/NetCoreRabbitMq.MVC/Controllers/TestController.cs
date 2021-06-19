using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipFirstProject.MVC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize]
        [HttpGet("GetValues")]
        public IActionResult GetValues()
        {
            var email = from c in  User.Claims.Where(f => f.Type.Contains("email")) select new { c.Type, c.Value };
            return Ok(new { Id = 1, Description = "Authorization Test", UserEmail = email.FirstOrDefault().Value });
        }

        [HttpGet("GetValues2")]
        public IActionResult GetValues2()
        {
            return Ok(new { Id = 2, Description = "Authorization Test2" });
        }
    }
}
