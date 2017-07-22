using System;
using System.Collections.Generic;
using System.Linq;
using Green.Core.Data;
using Green.Core.Domain.Votes;

namespace Green.Services.Votes
{
	public class VoteService
	{
		#region Fields

		private readonly IRepository<Vote> _voteRepository;

		#endregion

		#region Constructor

		/// <summary>
		/// Initializes a new instance of the <see cref="T:Green.Services.Votes.VoteService"/> class.
		/// </summary>
		/// <param name="voteRepository">Vote repository.</param>
		public VoteService(IRepository<Vote> voteRepository)
		{
			this._voteRepository = voteRepository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Inserts the vote.
		/// </summary>
		/// <param name="vote">Vote.</param>
		public void InsertVote(Vote vote)
		{
			if (vote == null)
				throw new ArgumentNullException(nameof(vote));


			_voteRepository.Insert(vote);
		}

		/// <summary>
		/// Gets all votes.
		/// </summary>
		/// <returns>The all votes.</returns>
		public IList<Vote> GetAllVotes()
		{
			return _voteRepository.Table.ToList();
		}

		/// <summary>
		/// Gets the vote by GUID.
		/// </summary>
		/// <returns>The vote by GUID.</returns>
		/// <param name="voteGuid">Vote GUID.</param>
		public Vote GetVoteByGuid(Guid voteGuid)
		{
			if (voteGuid == Guid.Empty)
				return null;

			var query = from v in _voteRepository.Table
						where v.Key == voteGuid
						orderby v.CreatedDateOnUtc
						select v;
			var vote = query.FirstOrDefault();

			return vote;
		}


		/// <summary>
		/// Updates the vote.
		/// </summary>
		/// <param name="vote">Vote.</param>
		public void UpdateVote(Vote vote)
		{
			if (vote == null)
				throw new ArgumentNullException(nameof(vote));

			_voteRepository.Update(vote);
		}


		#endregion
	}
}
