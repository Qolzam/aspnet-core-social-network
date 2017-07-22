using System;
using System.Collections.Generic;
using System.Linq;
using Green.Core.Data;
using Green.Core.Domain.Comments;

namespace Green.Services.Comments
{
    public class CommentService
    {
		#region Fields

		private readonly IRepository<Comment> _commentRepository;

		#endregion

		#region Constructor


		/// <summary>
		/// Initializes a new instance of the <see cref="T:Green.Services.Comments.CommentService"/> class.
		/// </summary>
		/// <param name="commentRepository">Comment repository.</param>
		public CommentService(IRepository<Comment> commentRepository)
		{
			this._commentRepository = commentRepository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Inserts the comment.
		/// </summary>
		/// <param name="comment">Comment.</param>
		public void InsertComment(Comment comment)
		{
			if (comment == null)
				throw new ArgumentNullException(nameof(comment));


			_commentRepository.Insert(comment);
		}

		/// <summary>
		/// Gets all comments.
		/// </summary>
		/// <returns>The all comments.</returns>
		public IList<Comment> GetAllComments()
		{
			return _commentRepository.Table.ToList();
		}

		/// <summary>
		/// Gets the comment by identifier.
		/// </summary>
		/// <returns>The comment by identifier.</returns>
		/// <param name="commentId">Comment identifier.</param>
		public Comment GetCommentById(int commentId)
		{
			if (commentId == 0)
				return null;

			return _commentRepository.GetById(commentId);
		}

		/// <summary>
		/// Gets the comment by GUID.
		/// </summary>
		/// <returns>The comment by GUID.</returns>
		/// <param name="commentGuid">Comment GUID.</param>
		public Comment GetCommentByGuid(Guid commentGuid)
		{
			if (commentGuid == Guid.Empty)
				return null;

			var query = from com in _commentRepository.Table
						where com.Key == commentGuid
						orderby com.Id
						select com;
			var comment = query.FirstOrDefault();

			return comment;
		}

		/// <summary>
		/// Updates the comment.
		/// </summary>
		/// <param name="comment">Comment.</param>
		public void UpdateComment(Comment comment)
		{
			if (comment == null)
				throw new ArgumentNullException(nameof(comment));

			_commentRepository.Update(comment);
		}


		#endregion
	}
}
