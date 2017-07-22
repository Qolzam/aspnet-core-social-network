using System;
using Green.Core.Domain.Users;

namespace Green.Core.Domain.Circles
{
    public class UserCircle
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Green.Core.Domain.Circles.UserCircle"/> is owner.
        /// </summary>
        /// <value><c>true</c> if is owner; otherwise, <c>false</c>.</value>
        public bool IsOwner
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int UserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the circle identifier.
        /// </summary>
        /// <value>The circle identifier.</value>
        public int CircleId
        {
            get;
            set;
        }

        #region Navigation properties

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public User User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the circle.
        /// </summary>
        /// <value>The circle.</value>
        public Circle Circle
        {
            get;
            set;
        }

        #endregion
    }
}
