using System;
using System.Collections.Generic;
using System.Linq;
using Green.Core;
using Green.Core.Data;
using Green.Core.Domain.Users;

namespace Green.Services.Users
{
    public class UserService:IUserService
    {

        #region Fields

        private readonly IRepository<User> _userRepository;
        private readonly IWebHelper _webHelper;

        #endregion

        #region Constructor


        /// <summary>
        /// Initializes a new instance of the <see cref="T:Green.Services.Users.UserService"/> class.
        /// </summary>
        /// <param name="userRepository">User repository.</param>
        public UserService(IRepository<User> userRepository, IWebHelper webHelper)
        {
            this._userRepository = userRepository;
            this._webHelper = webHelper;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Inserts the user.
        /// </summary>
        /// <param name="user">User.</param>
        public void InsertUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            user.LastIpAddress = _webHelper.GetCurrentIpAddress();

            _userRepository.Insert(user);
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>The all users.</returns>
        public IList<User> GetAllUsers(){
            return _userRepository.Table.ToList();
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <returns>The user by identifier.</returns>
        /// <param name="userId">User identifier.</param>
        public User GetUserById(int userId)
        {
            if (userId == 0)
                return null;

           return _userRepository.GetById(userId);
        }

        /// <summary>
        /// Gets the user by GUID.
        /// </summary>
        /// <returns>The user by GUID.</returns>
        /// <param name="userGuid">User GUID.</param>
        public User GetUserByGuid(Guid userGuid)
        {
            if (userGuid == Guid.Empty)
                return null;

            var query = from u in _userRepository.Table
                        where u.Key == userGuid
                        orderby u.Id
                        select u;
            var user = query.FirstOrDefault();

            return user;
        }

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <returns>The user by email.</returns>
        /// <param name="email">Email.</param>
		public User GetUserByEmail(string email)
		{
            if (string.IsNullOrEmpty(email))
                return null;

            var query = from u in _userRepository.Table
                        where u.Email == email
                        orderby u.Id
                        select u;
            var user = query.FirstOrDefault();

            return user;
		}

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">User.</param>
        public void UpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            
			user.LastIpAddress = _webHelper.GetCurrentIpAddress();

			_userRepository.Update(user);
        }

		/// <summary>
		/// If email exist.
		/// </summary>
		/// <returns><c>true</c>, if the email is exist, <c>false</c> otherwise.</returns>
		/// <param name="email">Email.</param>
		public bool EmailExist(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            var query = from u in _userRepository.Table
                        where u.Email.Equals(email)
                        select u;
            return query.Any();
        }


        #endregion
    }
}
