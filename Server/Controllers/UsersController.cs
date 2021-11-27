using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Server.Services;
using ToDo.Shared;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        /* private UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        } */

        [HttpGet("getcurrentuser")]
        public async Task<ActionResult<Users>> GetCurrentUser() {

            Users currentUser = new Users();

            if (User.Identity.IsAuthenticated)
            {
               /* currentUser.EmailAddress = User.FindFirstValue(ClaimTypes.Email);
                currentUser = await _context.Users.Where(u => u.EmailAddress == currentUser.EmailAddress).FirstOrDefaultAsync();

                if (currentUser == null)
                {
                    currentUser = new User();
                    currentUser.UserId = _context.Users.Max(user => user.UserId) + 1;
                    currentUser.EmailAddress = User.FindFirstValue(ClaimTypes.Email);
                    currentUser.Password = Utility.Encrypt(currentUser.EmailAddress);
                    currentUser.Source = "EXTL";

                    _context.Users.Add(currentUser);
                    await _context.SaveChangesAsync();
                }*/

                                     
                    currentUser.Email = User.FindFirstValue(ClaimTypes.Email);                    
                    currentUser.Name = "EXTL";
            }

            return await Task.FromResult(currentUser);

        }
    }
}