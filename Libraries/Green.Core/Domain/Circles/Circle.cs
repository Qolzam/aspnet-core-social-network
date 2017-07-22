using System;
using System.Collections.Generic;
using Green.Core.Domain.Users;

namespace Green.Core.Domain.Circles
{
    public class Circle : BaseEntity
    {

		private ICollection<UserCircle> _userCircles;


		/// <summary>
		/// Gets or sets the name of the circle.
		/// </summary>
		/// <value>The name of the circle.</value>
		public string CircleName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Green.Core.Domain.Circles.Circle"/> is system.
        /// </summary>
        /// <value><c>true</c> if is system; otherwise, <c>false</c>.</value>
        public bool IsSystem
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the followers counter.
        /// </summary>
        /// <value>The followers counter.</value>
        public int FollowersCounter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the following counter.
        /// </summary>
        /// <value>The following counter.</value>
        public int FollowingCounter
        {
            get;
            set;
        }

		#region Navigation Properties

		/// <summary>
		/// Gets or sets the user circles.
		/// </summary>
		/// <value>The user circles.</value>
		public virtual ICollection<UserCircle> UserCircles
		{
			get { return _userCircles ?? (_userCircles = new List<UserCircle>()); }
			protected set { _userCircles = value; }

		}

        #endregion
    }
}

