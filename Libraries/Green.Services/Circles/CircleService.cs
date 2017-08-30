using System;
using System.Collections.Generic;
using System.Linq;
using Green.Core.Data;
using Green.Core.Domain.Circles;

namespace Green.Services.Circles
{
    public class CircleService: ICircleService
    {
		#region Fields

		private readonly IRepository<Circle> _circleRepository;

		#endregion

		#region Constructor


		/// <summary>
		/// Initializes a new instance of the <see cref="T:Green.Services.Circles.CircleService"/> class.
		/// </summary>
		/// <param name="circleRepository">Circle repository.</param>
		public CircleService(IRepository<Circle> circleRepository)
		{
			this._circleRepository = circleRepository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Inserts the circle.
		/// </summary>
		/// <param name="circle">Circle.</param>
		public void InsertCircle(Circle circle)
		{
			if (circle == null)
				throw new ArgumentNullException(nameof(circle));


			_circleRepository.Insert(circle);
		}

		/// <summary>
		/// Gets all circles.
		/// </summary>
		/// <returns>The all circles.</returns>
		public IList<Circle> GetAllCircles()
		{
			return _circleRepository.Table.ToList();
		}

		/// <summary>
		/// Gets the circle by identifier.
		/// </summary>
		/// <returns>The circle by identifier.</returns>
		/// <param name="circleId">Circle identifier.</param>
		public Circle GetCircleById(int circleId)
		{
			if (circleId == 0)
				return null;

			return _circleRepository.GetById(circleId);
		}

		/// <summary>
		/// Gets the circle by GUID.
		/// </summary>
		/// <returns>The circle by GUID.</returns>
		/// <param name="circleGuid">Circle GUID.</param>
		public Circle GetCircleByGuid(Guid circleGuid)
		{
			if (circleGuid == Guid.Empty)
				return null;

			var query = from c in _circleRepository.Table
						where c.Key == circleGuid
						orderby c.Id
						select c;
			var circle = query.FirstOrDefault();

			return circle;
		}

		/// <summary>
		/// Updates the circle.
		/// </summary>
		/// <param name="circle">Circle.</param>
		public void UpdateCircle(Circle circle)
		{
			if (circle == null)
				throw new ArgumentNullException(nameof(circle));

			_circleRepository.Update(circle);
		}


		#endregion
	}
}
