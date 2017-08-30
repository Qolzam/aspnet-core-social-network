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
		/// Updates the userUserCircle.
		/// </summary>
		/// <param name="userUserCircle">UserCircle.</param>
		void UpdateUserCircle(UserCircle userUserCircle);
	}


}
