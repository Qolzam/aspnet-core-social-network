using System;
using Green.Core.Domain.Posts;
using Green.Core.Domain.Users;

namespace Green.Core.Domain.Comments
{
    public class Comment:BaseEntity
    {

        /// <summary>
        /// Gets or sets the text of comment.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>The score.</value>
        public int Score
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
        /// Gets or sets the post.
        /// </summary>
        /// <value>The post.</value>
        public Post Post
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user who write the comment.
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
