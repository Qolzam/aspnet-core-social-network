using System;
using System.Collections.Generic;
using Green.Core.Domain.Comments;
using Green.Core.Domain.Users;
using Green.Core.Domain.Votes;

namespace Green.Core.Domain.Posts
{
    public class Post : BaseEntity
    {

		private ICollection<Vote> _votes;
		private ICollection<Comment> _comments;


		/// <summary>
		/// Gets or sets the body of post.
		/// </summary>
		/// <value>The body of post.</value>
		public string Body
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the commnet counter.
        /// </summary>
        /// <value>The commnet counter.</value>
        public int CommnetCounter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the deleted date on UTC.
        /// </summary>
        /// <value>The deleted date on UTC.</value>
        public DateTime DeletedDateOnUtc
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Green.Core.Domain.Posts.Post"/> is deleted.
        /// </summary>
        /// <value><c>true</c> if deleted; otherwise, <c>false</c>.</value>
        public bool Deleted
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Green.Core.Domain.Posts.Post"/> disable comment.
        /// </summary>
        /// <value><c>true</c> if disable comment; otherwise, <c>false</c>.</value>
        public bool DisableComment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Green.Core.Domain.Posts.Post"/> disable sharing.
        /// </summary>
        /// <value><c>true</c> if disable sharing; otherwise, <c>false</c>.</value>
        public bool DisableSharing
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the image identifier.
        /// </summary>
        /// <value>The image identifier.</value>
        public int ImageId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the last edit on UTC.
        /// </summary>
        /// <value>The last edit on UTC.</value>
        public DateTime LastEditOnUtc
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the owner user identifier.
        /// </summary>
        /// <value>The owner user identifier.</value>
        public int OwnerUserId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the post type identifier.
        /// </summary>
        /// <value>The post type identifier.</value>
        public int PostTypeId
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
        /// Gets or sets the view count.
        /// </summary>
        /// <value>The view count.</value>
        public int ViewCount
        {
            get;
            set;
        }


        #region Navigation properties

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public User Owner
        {
            get;
            set;
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

        /// <summary>
        /// Gets or sets the commnets.
        /// </summary>
        /// <value>The commnets.</value>
		public virtual ICollection<Comment> Comments
		{
            get { return _comments ?? (_comments = new List<Comment>()); }
			protected set { _comments = value; }
		}

        #endregion
    }
}
