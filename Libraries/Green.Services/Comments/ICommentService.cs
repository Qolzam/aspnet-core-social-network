using System;
using System.Collections.Generic;
using Green.Core.Domain.Comments;

namespace Green.Services.Comments
{
    public interface ICommentService
    {
		/// <summary>
		/// Inserts the comment.
		/// </summary>
		/// <param name="comment">Comment.</param>
		void InsertComment(Comment comment);

		/// <summary>
		/// Gets all comments.
		/// </summary>
		/// <returns>The all comments.</returns>
		IList<Comment> GetAllComments();

		/// <summary>
		/// Gets the comment by identifier.
		/// </summary>
		/// <returns>The comment by identifier.</returns>
		/// <param name="commentId">ircle identifier.</param>
		Comment GetCommentById(int commentId);

		/// <summary>
		/// Gets the comment by GUID.
		/// </summary>
		/// <returns>The comment by GUID.</returns>
		/// <param name="commentGuid">Comment GUID.</param>
		Comment GetCommentByGuid(Guid commentGuid);

		/// <summary>
		/// Gets the comment by email.
		/// </summary>
		/// <returns>The comment by email.</returns>
		/// <param name="email">Email.</param>
		Comment GetCommentByEmail(string email);

		/// <summary>
		/// Updates the comment.
		/// </summary>
		/// <param name="comment">Comment.</param>
		void UpdateComment(Comment comment);
    }
}
