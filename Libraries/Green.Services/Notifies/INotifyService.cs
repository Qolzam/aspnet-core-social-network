using System;
using System.Collections.Generic;
using Green.Core.Domain.Notifies;

namespace Green.Services.Notifies
{
    public interface INotifyService
    {
		/// <summary>
		/// Inserts the notify.
		/// </summary>
		/// <param name="notify">Notify.</param>
		void InsertNotify(Notify notify);

		/// <summary>
		/// Gets all notifys.
		/// </summary>
		/// <returns>The all notifys.</returns>
		IList<Notify> GetAllNotifys();

		/// <summary>
		/// Gets the notify by identifier.
		/// </summary>
		/// <returns>The notify by identifier.</returns>
		/// <param name="notifyId">ircle identifier.</param>
		Notify GetNotifyById(int notifyId);

		/// <summary>
		/// Gets the notify by GUID.
		/// </summary>
		/// <returns>The notify by GUID.</returns>
		/// <param name="notifyGuid">Notify GUID.</param>
		Notify GetNotifyByGuid(Guid notifyGuid);

		/// <summary>
		/// Gets the notify by email.
		/// </summary>
		/// <returns>The notify by email.</returns>
		/// <param name="email">Email.</param>
		Notify GetNotifyByEmail(string email);

		/// <summary>
		/// Updates the notify.
		/// </summary>
		/// <param name="notify">Notify.</param>
		void UpdateNotify(Notify notify);
    }
}
