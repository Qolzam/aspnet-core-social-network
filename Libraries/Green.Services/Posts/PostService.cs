using System;
using System.Collections.Generic;
using System.Linq;
using Green.Core.Data;
using Green.Core.Domain.Posts;

namespace Green.Services.Posts
{
	public class PostService
	{
		#region Fields

		private readonly IRepository<Post> _postRepository;

		#endregion

		#region Constructor


		/// <summary>
		/// Initializes a new instance of the <see cref="T:Green.Services.Posts.PostService"/> class.
		/// </summary>
		/// <param name="postRepository">Post repository.</param>
		public PostService(IRepository<Post> postRepository)
		{
			this._postRepository = postRepository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Inserts the post.
		/// </summary>
		/// <param name="post">Post.</param>
		public void InsertPost(Post post)
		{
			if (post == null)
				throw new ArgumentNullException(nameof(post));


			_postRepository.Insert(post);
		}

		/// <summary>
		/// Gets all posts.
		/// </summary>
		/// <returns>The all posts.</returns>
		public IList<Post> GetAllPosts()
		{
			return _postRepository.Table.ToList();
		}

		/// <summary>
		/// Gets the post by identifier.
		/// </summary>
		/// <returns>The post by identifier.</returns>
		/// <param name="postId">Post identifier.</param>
		public Post GetPostById(int postId)
		{
			if (postId == 0)
				return null;

			return _postRepository.GetById(postId);
		}

		/// <summary>
		/// Gets the post by GUID.
		/// </summary>
		/// <returns>The post by GUID.</returns>
		/// <param name="postGuid">Post GUID.</param>
		public Post GetPostByGuid(Guid postGuid)
		{
			if (postGuid == Guid.Empty)
				return null;

			var query = from p in _postRepository.Table
						where p.Key == postGuid
						orderby p.Id
						select p;
			var post = query.FirstOrDefault();

			return post;
		}

		/// <summary>
		/// Updates the post.
		/// </summary>
		/// <param name="post">Post.</param>
		public void UpdatePost(Post post)
		{
			if (post == null)
				throw new ArgumentNullException(nameof(post));

			_postRepository.Update(post);
		}


		#endregion
	}
}
