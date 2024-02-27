using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using RepoLayer.Entiry;
using System.Collections;
using System.Collections.Generic;


namespace EntiryFrameworkTstProject1.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBL userBL;

        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost]
        
        public IActionResult AddUser(UserModel userModel)
        {
            var result = userBL.AddUserDetails(userModel);
            if (result != null)
            {
                return Ok(new { Success = true, Message = "added sucessfully", Data = result });
            }
            else
            {
                return BadRequest(new { Success = false, Message = "something wet wrong" });
            }
        }
        [HttpGet]
        public IActionResult ViewUserDetail()
        {
            IEnumerable<UserEntiry> entity = userBL.ViewUserDetail();
            return Ok(entity);

           


        }

        

    }
}
