using System;
using System.Collections.Generic;
using Green.Core;
using Green.Core.Domain.Users;
using Green.Services.Authentication;
using Green.Services.Security;
using Green.Services.Users;
using Green.Web.Framework.Helpers;
using Green.Web.Models.Users;
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
            if (string.IsNullOrEmpty(loginModel.UserName))
            {
                ModelState.AddModelError(nameof(loginModel), "User name can't be null or empty.");
            }

            if (string.IsNullOrEmpty(loginModel.Password))
			{
				ModelState.AddModelError(nameof(loginModel), "Password can't be null or empty.");
			}


           var user = _userService.GetUserByEmail(loginModel.UserName);
            if (user == null)
            {
                ModelState.AddModelError(nameof(loginModel),"User name or password is wrong.");
            }

			if (!ModelState.IsValid)
			{
				// return 422
				return new UnprocessableEntityObjectResult(ModelState);
			}

            //encrypting password
            string encryptedPassword = _encryptionService.EncryptText(loginModel.Password);

            if(!encryptedPassword.Equals(user.Password)){
				return Unauthorized();
            }

            _authService.SignIn(user,loginModel.IsPersistent);

			return Ok(user);

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
                ModelState.AddModelError(nameof(userModel),"Full name can't be null or empty.");
            }

			if (string.IsNullOrEmpty(userModel.Email))
			{
				ModelState.AddModelError(nameof(userModel), "Email can't be null or empty.");
            }
            else if(_userService.EmailExist(userModel.Email))
            {
                ModelState.AddModelError(nameof(userModel), "Email exist.");
            }



            if (string.IsNullOrEmpty(userModel.Password))
			{
				ModelState.AddModelError(nameof(userModel), "Password can't be null or empty.");
			}

            if (string.IsNullOrEmpty(userModel.ConfirmPassword))
			{
				ModelState.AddModelError(nameof(userModel), "Confirm password can't be null or empty.");
			}

            if (!userModel.Password.Equals(userModel.ConfirmPassword))
			{
				ModelState.AddModelError(nameof(userModel), "Password and confirm password should be equal.");
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
                return Unauthorized();
            }


            _authService.SignOut();

            return Ok();
        }


        [HttpPut("password")]
        public IActionResult Password([FromForm] UpdatePasswordModel passwordModel)
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
				return Unauthorized();
			}

            if (string.IsNullOrEmpty(passwordModel.NewPassword))
            {
                ModelState.AddModelError(nameof(passwordModel),"New password can't be null or empty.");
            }

            if (string.IsNullOrEmpty(passwordModel.ConfirmPassword))
			{
				ModelState.AddModelError(nameof(passwordModel), "Confirm password can't be null or empty.");
			}

            if (!passwordModel.NewPassword.Equals(passwordModel.ConfirmPassword))
            {
				ModelState.AddModelError(nameof(passwordModel), "New password and confirm password should be equal.");
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
