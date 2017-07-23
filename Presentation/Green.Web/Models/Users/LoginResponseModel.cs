using System;
namespace Green.Web.Models.Users
{
    public class LoginResponseModel
    {
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public Guid Key
        {
            get;
            set;
        }

		/// <summary>
		/// Gets or sets the email.
		/// </summary>
		/// <value>The email.</value>
		public string Email
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the full name.
		/// </summary>
		/// <value>The full name.</value>
		public string FullName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the tag line.
		/// </summary>
		/// <value>The tag line.</value>
		public string TagLine
		{
			get;
			set;
		}


    }
}
