using System;
using System.Collections.Generic;
using Green.Core.Domain.Users;

namespace Green.Services.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="user">User.</param>
        void InsertUser(User user);

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>The all users.</returns>
        IList<User> GetAllUsers();

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <returns>The user by identifier.</returns>
        /// <param name="userId">User identifier.</param>
        User GetUserById(int userId);

        /// <summary>
        /// Gets the user by GUID.
        /// </summary>
        /// <returns>The user by GUID.</returns>
        /// <param name="userGuid">User GUID.</param>
        User GetUserByGuid(Guid userGuid);

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <returns>The user by email.</returns>
        /// <param name="email">Email.</param>
        User GetUserByEmail(string email);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">User.</param>
        void UpdateUser(User user);

		/// <summary>
		/// If email exist.
		/// </summary>
		/// <returns><c>true</c>, if the email is exist, <c>false</c> otherwise.</returns>
		/// <param name="email">Email.</param>
		bool EmailExist(string email);

      
    }


}
