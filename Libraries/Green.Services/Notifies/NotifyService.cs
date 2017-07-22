using System;
using System.Collections.Generic;
using System.Linq;
using Green.Core.Data;
using Green.Core.Domain.Notifies;

namespace Green.Services.Notifies
{
    public class NotifyService
    {
		#region Fields

		private readonly IRepository<Notify> _notifyRepository;

		#endregion

		#region Constructor


		/// <summary>
		/// Initializes a new instance of the <see cref="T:Green.Services.Notifys.NotifyService"/> class.
		/// </summary>
		/// <param name="notifyRepository">Notify repository.</param>
		public NotifyService(IRepository<Notify> notifyRepository)
		{
			this._notifyRepository = notifyRepository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Inserts the notify.
		/// </summary>
		/// <param name="notify">Notify.</param>
		public void InsertNotify(Notify notify)
		{
			if (notify == null)
				throw new ArgumentNullException(nameof(notify));


			_notifyRepository.Insert(notify);
		}

		/// <summary>
		/// Gets all notifys.
		/// </summary>
		/// <returns>The all notifys.</returns>
		public IList<Notify> GetAllNotifys()
		{
			return _notifyRepository.Table.ToList();
		}

		/// <summary>
		/// Gets the notify by identifier.
		/// </summary>
		/// <returns>The notify by identifier.</returns>
		/// <param name="notifyId">Notify identifier.</param>
		public Notify GetNotifyById(int notifyId)
		{
			if (notifyId == 0)
				return null;

			return _notifyRepository.GetById(notifyId);
		}

		/// <summary>
		/// Gets the notify by GUID.
		/// </summary>
		/// <returns>The notify by GUID.</returns>
		/// <param name="notifyGuid">Notify GUID.</param>
		public Notify GetNotifyByGuid(Guid notifyGuid)
		{
			if (notifyGuid == Guid.Empty)
				return null;

			var query = from n in _notifyRepository.Table
						where n.Key == notifyGuid
						orderby n.Id
						select n;
			var notify = query.FirstOrDefault();

			return notify;
		}

		/// <summary>
		/// Updates the notify.
		/// </summary>
		/// <param name="notify">Notify.</param>
		public void UpdateNotify(Notify notify)
		{
			if (notify == null)
				throw new ArgumentNullException(nameof(notify));

			_notifyRepository.Update(notify);
		}


		#endregion
	}
}
