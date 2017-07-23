using System;
namespace Green.Web.Models.Users
{
    public class LoginModel
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
       public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Green.Web.Models.Users.LoginModel"/> is persistent.
        /// </summary>
        /// <value><c>true</c> if the authentication session is persistent across multiple request; otherwise, <c>false</c>.</value>
        public bool IsPersistent
        {
            get;
            set;
        }
    }
}
