using System;
using System.Collections.Generic;
using Green.Core;
using Green.Core.Domain.Users;
using Green.Services.Authentication;
using Green.Services.Security;
using Green.Services.Users;
using Green.Web.Framework.Helpers;
using Green.Web.Models.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Green.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizationController : Controller
    {

        #region Fields

        private readonly IUserService _userService;
        private readonly IEncryptionService _encryptionService;
		private readonly IAuthenticationService _authService;


		#endregion


		#region Constructor

		public AuthorizationController(
            IUserService userService,
            IEncryptionService encryptionService,
            IAuthenticationService authService)
        {
            this._userService = userService;
            this._encryptionService = encryptionService;
            this._authService = authService;
        }

        #endregion


        [HttpGet]
        public IActionResult Get()
        {
			User user = _authService.GetAuthenticatedUser();

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user.Key);
        }


        [HttpPost("login")]
        public IActionResult Login([FromForm]LoginModel loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.Email))
            {
                ModelState.AddModelError("errors", "Email address can't be null or empty.");
            }

            if (string.IsNullOrEmpty(loginModel.Password))
			{
				ModelState.AddModelError("errors", "Password can't be null or empty.");
			}


           var user = _userService.GetUserByEmail(loginModel.Email);

            if (user == null)
            {
                ModelState.AddModelError("errors","Email address or password is wrong.");
            }

			if (!ModelState.IsValid)
			{
				// return 422
				return new UnprocessableEntityObjectResult(ModelState);
			}

            //encrypting password
            string encryptedPassword = _encryptionService.EncryptText(loginModel.Password);

            if(!encryptedPassword.Equals(user.Password)){

                return StatusCode(StatusCodes.Status401Unauthorized, new { errors = new string[] { "Email address or password is wrong." } });
            }

            if(!user.Active)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, new { errors = new string[] { $"{user.Email} user is inactive." } });

			}

			if (user.Deleted)
			{
				return StatusCode(StatusCodes.Status401Unauthorized, new { errors = new string[] { $"{user.Email} user has been deleted." } });

			}
            _authService.SignIn(user,loginModel.IsPersistent);

            return Ok(new LoginResponseModel { Email = user.Email, FullName = user.FullName, Key = user.Key, TagLine = user.TagLine});

		}


        [HttpPost("signup")]
        public IActionResult Signup([FromForm]UserRegisterModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest();

            }

            if(string.IsNullOrEmpty(userModel.FullName))
            {
                ModelState.AddModelError("errors","Full name can't be null or empty.");
            }

			if (string.IsNullOrEmpty(userModel.Email))
			{
				ModelState.AddModelError("errors", "Email can't be null or empty.");
            }
            else if(_userService.EmailExist(userModel.Email))
            {
                ModelState.AddModelError("errors", "Email exist.");
            }



            if (string.IsNullOrEmpty(userModel.Password))
			{
				ModelState.AddModelError("errors", "Password can't be null or empty.");
			}
			else if (!userModel.Password.Equals(userModel.ConfirmPassword))
			{
				ModelState.AddModelError("errors", "Password and confirm password should be equal.");
			}

            if (string.IsNullOrEmpty(userModel.ConfirmPassword))
			{
				ModelState.AddModelError("errors", "Confirm password can't be null or empty.");
			}



			if (!ModelState.IsValid)
			{
				// return 422
				return new UnprocessableEntityObjectResult(ModelState);
			}

            //encrypting password
            string encryptedPassword = _encryptionService.EncryptText(userModel.Password);

            User registerUser = new User
            {
                Active = true,
                CannotLoginUntilDateUtc = DateTime.UtcNow,
                CreatedOnUtc = DateTime.UtcNow,
                Deleted = false,
                Email = userModel.Email.Trim(),
                FailedLoginAttempts = 0,
                LastActivityDateUtc = DateTime.UtcNow,
                LastIpAddress = HttpContext.Connection.RemoteIpAddress.ToString(),
                LastLoginDateUtc = DateTime.UtcNow,
                UserName = userModel.Email.Trim(),
                FullName = userModel.FullName.Trim(),
                TagLine = " ",
                Password = encryptedPassword
                 
            };

            _userService.InsertUser(registerUser);

            return Ok(new { key = registerUser.Key });
        }

      
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            User user = null;

            try
            {
               user = _authService.GetAuthenticatedUser();
				if (user == null)
				{
					throw new GreenException("User is not authorized");
				}
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new { errors = new string[] { "User is not authorized to logout." } });
			}


            _authService.SignOut();

            return Ok();
        }


        [HttpPut("password")]
        public IActionResult Password([FromForm]UpdatePasswordModel passwordModel)
        {
            User user = null;

			try
			{
				user = _authService.GetAuthenticatedUser();
                if (user == null)
                {
                    throw new GreenException("User is not authorized");
                }
            }
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status403Forbidden, new { errors = new string[] { "User is not authorized to logout." } });
			}

            if (string.IsNullOrEmpty(passwordModel.NewPassword))
            {
                ModelState.AddModelError("errors","New password can't be null or empty.");
            }

            if (string.IsNullOrEmpty(passwordModel.ConfirmPassword))
			{
				ModelState.AddModelError("errors", "Confirm password can't be null or empty.");
			}
             else if (!string.IsNullOrEmpty(passwordModel.NewPassword) && !passwordModel.NewPassword.Equals(passwordModel.ConfirmPassword))
            {
				ModelState.AddModelError("errors", "New password and confirm password should be equal.");
            }

			if (!ModelState.IsValid)
			{
				// return 422
				return new UnprocessableEntityObjectResult(ModelState);
			}

			//encrypte password
			string encryptedPassword = _encryptionService.EncryptText(passwordModel.NewPassword);

            user.Password = encryptedPassword;
            _userService.UpdateUser(user);

            return Ok();
        }

		
    }
}
