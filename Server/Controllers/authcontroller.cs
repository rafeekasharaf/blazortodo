using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class authcontroller : ControllerBase
    {
        [HttpGet("google-login")]
        public async Task GoogleAuth() {
            
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = "/"});

            // await HttpContext.ChallengeAsync(
            //     prop,
            //     GoogleDefaults.AuthenticationScheme);
           if (User.Identity.IsAuthenticated){

            } 
        }

        [HttpGet("logoutuser")]
        public async Task<ActionResult<String>> LogOutUser()
        {
            await HttpContext.SignOutAsync();
            return "Success";
        }  
    }
}