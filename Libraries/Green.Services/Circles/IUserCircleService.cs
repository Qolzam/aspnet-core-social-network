using System;
using System.Collections.Generic;
using Green.Core.Domain.Circles;

namespace Green.Services.Circles
{
	public interface IUserCircleService
	{
		/// <summary>
		/// Inserts the userUserCircle.
		/// </summary>
		/// <param name="userUserCircle">UserCircle.</param>
		void InsertUserCircle(UserCircle userUserCircle);

		/// <summary>
		/// Gets all userUserCircles.
		/// </summary>
		/// <returns>The all userUserCircles.</returns>
		IList<UserCircle> GetAllUserCircles();

		/// <summary>
		/// Gets the userUserCircle by identifier.
		/// </summary>
		/// <returns>The userUserCircle by identifier.</returns>
		/// <param name="userUserCircleId">ircle identifier.</param>
		UserCircle GetUserCircleById(int userUserCircleId);

		/// <summary>
		/// Gets the userUserCircle by GUID.
		/// </summary>
		/// <returns>The userUserCircle by GUID.</returns>
		/// <param name="userUserCircleGuid">UserCircle GUID.</param>
		UserCircle GetUserCircleByGuid(Guid userUserCircleGuid);

		/// <summary>
		/// Gets the userUserCircle by email.
		/// </summary>
		/// <returns>The userUserCircle by email.</returns>
		/// <param name="email">Email.</param>
		UserCircle GetUserCircleByEmail(string email);

		/// <summary>
		/// Updates the userUserCircle.
		/// </summary>
		/// <param name="userUserCircle">UserCircle.</param>
		void UpdateUserCircle(UserCircle userUserCircle);
	}


}
