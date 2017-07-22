using System;
using Green.Core.Domain.Users;

namespace Green.Core.Domain.Notifies
{
    public class Notify : BaseEntity
    {


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Green.Core.Domain.Notifies.Notify"/> is seen.
        /// </summary>
        /// <value><c>true</c> if is seen; otherwise, <c>false</c>.</value>
        public bool IsSeen
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the URL to mention a page.
        /// </summary>
        /// <value>The URL.</value>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Green.Core.Domain.Notifies.Notify"/> is notifier.
        /// </summary>
        /// <value><c>true</c> if is notifier; otherwise, <c>false</c>.</value>
        public bool IsNotifier
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

        #endregion
    }
}
