using System;
using System.Collections.Generic;
using Green.Core.Domain.Votes;

namespace Green.Services.Votes
{
    public interface IVoteService
    {
		/// <summary>
		/// Inserts the vote.
		/// </summary>
		/// <param name="vote">Vote.</param>
		void InsertVote(Vote vote);

		/// <summary>
		/// Gets all votes.
		/// </summary>
		/// <returns>The all votes.</returns>
		IList<Vote> GetAllVotes();

		/// <summary>
		/// Gets the vote by identifier.
		/// </summary>
		/// <returns>The vote by identifier.</returns>
		/// <param name="voteId">ircle identifier.</param>
		Vote GetVoteById(int voteId);

		/// <summary>
		/// Gets the vote by GUID.
		/// </summary>
		/// <returns>The vote by GUID.</returns>
		/// <param name="voteGuid">Vote GUID.</param>
		Vote GetVoteByGuid(Guid voteGuid);

		/// <summary>
		/// Gets the vote by email.
		/// </summary>
		/// <returns>The vote by email.</returns>
		/// <param name="email">Email.</param>
		Vote GetVoteByEmail(string email);

		/// <summary>
		/// Updates the vote.
		/// </summary>
		/// <param name="vote">Vote.</param>
		void UpdateVote(Vote vote);
    }
}
