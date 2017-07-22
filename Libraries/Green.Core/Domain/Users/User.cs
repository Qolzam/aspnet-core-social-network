using System;
using System.Collections.Generic;
using Green.Core.Domain.Circles;
using Green.Core.Domain.ImageGallery;
using Green.Core.Domain.Notifies;
using Green.Core.Domain.Posts;
using Green.Core.Domain.Votes;

namespace Green.Core.Domain.Users
{
    public class User : BaseEntity
    {

		private ICollection<Image> _images;
		private ICollection<Post> _posts;
		private ICollection<Notify> _notifies;
		private ICollection<UserCircle> _userCircles;
        private ICollection<Vote> _votes;



		/// <summary>
		/// Initializes a new instance of the <see cref="T:Green.Core.Domain.Users.User"/> class.
		/// </summary>
		public User()
        {
            
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public String UserName
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

        /// <summary>
        /// Gets or sets the failed login attempts.
        /// </summary>
        /// <value>The failed login attempts.</value>
        public int FailedLoginAttempts
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the cannot login until date UTC.
        /// </summary>
        /// <value>The cannot login until date UTC.</value>
        public DateTime? CannotLoginUntilDateUtc
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Green.Core.Domain.Users.User"/> is active.
        /// </summary>
        /// <value><c>true</c> if active; otherwise, <c>false</c>.</value>
        public bool Active
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Green.Core.Domain.Users.User"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        public bool Deleted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last IP address.
        /// </summary>
        /// <value>The last IP address.</value>
        public string LastIpAddress
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last login date UTC.
        /// </summary>
        /// <value>The last login date UTC.</value>
        public DateTime? LastLoginDateUtc
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last activity date UTC.
        /// </summary>
        /// <value>The last activity date UTC.</value>
        public DateTime LastActivityDateUtc
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the avatar identifier.
        /// </summary>
        /// <value>The avatar identifier.</value>
        public int AvatarId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the banner identifier.
        /// </summary>
        /// <value>The banner identifier.</value>
        public int BannerId
        {
            get;
            set;
        }

		#region Navigation properties

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
		public virtual ICollection<Image> Images
		{
            get { return _images ?? (_images = new List<Image>()); }
			protected set { _images = value; }
		}

        /// <summary>
        /// Gets or sets the posts.
        /// </summary>
        /// <value>The posts.</value>
		public virtual ICollection<Post> Posts
		{
			get { return _posts ?? (_posts = new List<Post>()); }
			protected set { _posts = value; }
		}

        /// <summary>
        /// Gets or sets the notifies.
        /// </summary>
        /// <value>The notifies.</value>
        public virtual ICollection<Notify> Notifies
		{
            get { return _notifies ?? (_notifies = new List<Notify>()); }
			protected set { _notifies = value; }

		}

        /// <summary>
        /// Gets or sets the user circles.
        /// </summary>
        /// <value>The user circles.</value>
        public virtual ICollection<UserCircle> UserCircles
		{
            get { return _userCircles ?? (_userCircles = new List<UserCircle>()); }
			protected set { _userCircles = value; }


		}

        /// <summary>
        /// Gets or sets the votes.
        /// </summary>
        /// <value>The votes.</value>
		public virtual ICollection<Vote> Votes
		{
			get { return _votes ?? (_votes = new List<Vote>()); }
			protected set { _votes = value; }
		}


		#endregion


	}
}
