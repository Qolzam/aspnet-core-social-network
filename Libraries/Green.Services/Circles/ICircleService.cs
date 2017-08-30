using System;
using System.Collections.Generic;
using Green.Core.Domain.Circles;

namespace Green.Services.Circles
{
	public interface ICircleService
	{
		/// <summary>
		/// Inserts the circle.
		/// </summary>
		/// <param name="circle">Circle.</param>
		void InsertCircle(Circle circle);

		/// <summary>
		/// Gets all circles.
		/// </summary>
		/// <returns>The all circles.</returns>
		IList<Circle> GetAllCircles();

		/// <summary>
		/// Gets the circle by identifier.
		/// </summary>
		/// <returns>The circle by identifier.</returns>
		/// <param name="circleId">ircle identifier.</param>
		Circle GetCircleById(int circleId);

		/// <summary>
		/// Gets the circle by GUID.
		/// </summary>
		/// <returns>The circle by GUID.</returns>
		/// <param name="circleGuid">Circle GUID.</param>
		Circle GetCircleByGuid(Guid circleGuid);

		/// <summary>
		/// Updates the circle.
		/// </summary>
		/// <param name="circle">Circle.</param>
		void UpdateCircle(Circle circle);
	}


}
