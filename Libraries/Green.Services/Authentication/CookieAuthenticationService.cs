using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Green.Core.Domain.Users;
using Green.Services.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;


namespace Green.Services.Authentication
{
    /// <summary>
    /// Represents service using cookie middleware for the authentication
    /// </summary>
    public partial class CookieAuthenticationService : IAuthenticationService
    {
        #region Fields

        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private User _cachedUser;

        #endregion

        #region Ctor

        public CookieAuthenticationService(
            IUserService userService,
            IHttpContextAccessor httpContextAccessor)
        {
            this._userService = userService;
            this._httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="user">User</param>
        /// <param name="isPersistent">Whether the authentication session is persisted across multiple requests</param>
        public virtual void SignIn(User user, bool isPersistent)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            //create claims for username and email of the user
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.FullName, ClaimValueTypes.String, GreenCookieAuthenticationDefaults.ClaimsIssuer),
                new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email, GreenCookieAuthenticationDefaults.ClaimsIssuer)
            };

            //create principal for the current authentication scheme
            var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            //set value indicating whether session is persisted and the time at which the authentication was issued
            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = isPersistent,
                IssuedUtc = DateTime.UtcNow
            };

            //sign in
            httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authenticationProperties).Wait();


            //cache authenticated user
            _cachedUser = user;
        }

        /// <summary>
        /// Sign out
        /// </summary>
        public virtual void SignOut()
        {
			var httpContext = _httpContextAccessor.HttpContext;


		    //reset cached user
			_cachedUser = null;

            //and sign out from the current authentication scheme
            var signOutTask = httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            signOutTask.Wait();
        }

        /// <summary>
        /// Get authenticated user
        /// </summary>
        /// <returns>User</returns>
        public virtual User GetAuthenticatedUser()
        {

			var httpContext = _httpContextAccessor.HttpContext;

			//whether there is a cached user
			if (_cachedUser != null)
                return _cachedUser;

           
            //try to get authenticated user identity
            var authenticateTask = httpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = authenticateTask.Result;
            var userIdentity = userPrincipal?.Principal.Identities?.FirstOrDefault(identity => identity.IsAuthenticated);
            if (userIdentity == null)
                return null;

            User user = null;

                //try to get user by email
                var emailClaim = userIdentity.FindFirst(claim => claim.Type == ClaimTypes.Email 
                    && claim.Issuer.Equals(GreenCookieAuthenticationDefaults.ClaimsIssuer, StringComparison.InvariantCultureIgnoreCase));
                if (emailClaim != null)
                    user = _userService.GetUserByEmail(emailClaim.Value);
          
            //whether the found user is available
            if (user == null || !user.Active || user.Deleted)
                return null;

            //cache authenticated user
            _cachedUser = user;

            return _cachedUser;
        }

        #endregion
    }
}