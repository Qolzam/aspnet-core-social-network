using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Green.Core.Domain.Users;
using Green.Services.Users;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Green.Web.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

		#region Fields

		private readonly IUserService _userService;

        #endregion

        #region Constructor

        public UserController(IUserService userService)
        {
			this._userService = userService;
        }

		#endregion

		#region Methods

		[HttpGet]
		public IActionResult Get()
		{

            string startupPath = new HostingEnvironment().ContentRootPath;

            string startupPath2 = Environment.CurrentDirectory;

			var user = new User()
			{
				Active = true,
				CannotLoginUntilDateUtc = DateTime.UtcNow,
				CreatedOnUtc = DateTime.UtcNow,
				Deleted = false,
				Email = "email.com",
				FailedLoginAttempts = 0,
				LastActivityDateUtc = DateTime.UtcNow,
				LastIpAddress = "09.3.2.2",
				LastLoginDateUtc = DateTime.UtcNow,
				UserName = "new user",
				FullName = "user"
			};

			var users = _userService.GetAllUsers();
            return Ok(new {users, startupPath, startupPath2});
		}

        #endregion

       
    }
}
