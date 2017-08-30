using System;
using System.Collections.Generic;
using System.Linq;
using Green.Core.Data;
using Green.Core.Domain.Circles;

namespace Green.Services.Circles
{
    public class UserCircleService: IUserCircleService
    {
		#region Fields

		private readonly IRepository<UserCircle> _userCircleRepository;

		#endregion

		#region Constructor


		/// <summary>
		/// Initializes a new instance of the <see cref="T:Green.Services.UserCircles.UserCircleService"/> class.
		/// </summary>
		/// <param name="userCircleRepository">UserCircle repository.</param>
		public UserCircleService(IRepository<UserCircle> userCircleRepository)
		{
			this._userCircleRepository = userCircleRepository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Inserts the userCircle.
		/// </summary>
		/// <param name="userCircle">UserCircle.</param>
		public void InsertUserCircle(UserCircle userCircle)
		{
			if (userCircle == null)
				throw new ArgumentNullException(nameof(userCircle));


			_userCircleRepository.Insert(userCircle);
		}

		/// <summary>
		/// Gets all userCircles.
		/// </summary>
		/// <returns>The all userCircles.</returns>
		public IList<UserCircle> GetAllUserCircles()
		{
			return _userCircleRepository.Table.ToList();
		}

		/// <summary>
		/// Updates the userCircle.
		/// </summary>
		/// <param name="userCircle">UserCircle.</param>
		public void UpdateUserCircle(UserCircle userCircle)
		{
			if (userCircle == null)
				throw new ArgumentNullException(nameof(userCircle));

			_userCircleRepository.Update(userCircle);
		}


		#endregion
	}
}
