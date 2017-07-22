using System;
namespace Green.Web.Models.Users
{
    public class UpdatePasswordModel
    {
        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        /// <value>The new password.</value>
        public string NewPassword
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>The confirm password.</value>
        public string ConfirmPassword
        {
            get;
            set;
        }
    }
}
