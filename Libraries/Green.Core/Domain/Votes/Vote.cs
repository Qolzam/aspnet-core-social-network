using System;
using Green.Core.Domain.Posts;
using Green.Core.Domain.Users;

namespace Green.Core.Domain.Votes
{
    public class Vote 
    {

        public Vote()
        {
            this.CreatedDateOnUtc = DateTime.UtcNow;
            this.Key = Guid.NewGuid();

        }

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
        /// Gets or sets the created date on UTC.
        /// </summary>
        /// <value>The created date on UTC.</value>
        public DateTime CreatedDateOnUtc
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the post identifier.
        /// </summary>
        /// <value>The post identifier.</value>
        public int PostId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the voter identifier.
        /// </summary>
        /// <value>The voter identifier.</value>
        public int VoterId
        {
            get;
            set;
        }

        #region Navigation properties

        /// <summary>
        /// Gets or sets the post.
        /// </summary>
        /// <value>The post.</value>
        public Post Post
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the voter.
        /// </summary>
        /// <value>The voter.</value>
        public User Voter
        {
            get;
            set;
        }

        #endregion

    }
}
