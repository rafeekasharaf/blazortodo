using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class authcontroller : ControllerBase
    {
        [HttpGet("google-login")]
        public async Task GoogleAuth() {
            
         /* string returnUrl = "/signin-google";
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, 
            new AuthenticationProperties { 
               RedirectUri = "/"
            //    RedirectUri = Url.Page("/", 
            //     pageHandler: "Callback", 
            //     values: new { returnUrl }),
            });*/

            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
        await HttpContext.ChallengeAsync( GoogleDefaults.AuthenticationScheme, properties);

            // await HttpContext.ChallengeAsync(
            //     prop,
            //     GoogleDefaults.AuthenticationScheme);
           if (User.Identity.IsAuthenticated){

            } 
        }

        [Route("google-response")]
    public async Task<IActionResult> GoogleResponse()
    {
        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
 
        var claims = result.Principal.Identities
            .FirstOrDefault().Claims.Select(claim => new
        {
            claim.Issuer,
            claim.OriginalIssuer,
            claim.Type,
            claim.Value
        });
 
       // return JsonResult(claims);
       return LocalRedirect("/");
    }

        public async Task<IActionResult> OnGetCallbackAsync(
            string returnUrl = null, string remoteError = null)
        {
            // Get the information about the user from the external login provider
            var GoogleUser = this.User.Identities.FirstOrDefault();
            if (GoogleUser.IsAuthenticated)
            {
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    RedirectUri = this.Request.Host.Value
                };
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(GoogleUser),
                authProperties);
            }
            return LocalRedirect("/ffff");
        }
    

        [HttpGet("logoutuser")]
        public async Task<ActionResult<String>> LogOutUser()
        {
            await HttpContext.SignOutAsync();
            return "Success";
        }  
    }
}