using System;
using System.Collections.Generic;
using Green.Core.Domain.Posts;

namespace Green.Services.Posts
{
    public interface IPostService
    {
		/// <summary>
		/// Inserts the post.
		/// </summary>
		/// <param name="post">Post.</param>
		void InsertPost(Post post);

		/// <summary>
		/// Gets all posts.
		/// </summary>
		/// <returns>The all posts.</returns>
		IList<Post> GetAllPosts();

		/// <summary>
		/// Gets the post by identifier.
		/// </summary>
		/// <returns>The post by identifier.</returns>
		/// <param name="postId">ircle identifier.</param>
		Post GetPostById(int postId);

		/// <summary>
		/// Gets the post by GUID.
		/// </summary>
		/// <returns>The post by GUID.</returns>
		/// <param name="postGuid">Post GUID.</param>
		Post GetPostByGuid(Guid postGuid);

		/// <summary>
		/// Gets the post by email.
		/// </summary>
		/// <returns>The post by email.</returns>
		/// <param name="email">Email.</param>
		Post GetPostByEmail(string email);

		/// <summary>
		/// Updates the post.
		/// </summary>
		/// <param name="post">Post.</param>
		void UpdatePost(Post post);
    }
}
