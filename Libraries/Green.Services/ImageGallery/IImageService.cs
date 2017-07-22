using System;
using System.Collections.Generic;
using Green.Core.Domain.ImageGallery;

namespace Green.Services.ImageGallery
{
    public interface IImageService
    {
		/// <summary>
		/// Inserts the image.
		/// </summary>
		/// <param name="image">Image.</param>
		void InsertImage(Image image);

		/// <summary>
		/// Gets all images.
		/// </summary>
		/// <returns>The all images.</returns>
		IList<Image> GetAllImages();

		/// <summary>
		/// Gets the image by identifier.
		/// </summary>
		/// <returns>The image by identifier.</returns>
		/// <param name="imageId">ircle identifier.</param>
		Image GetImageById(int imageId);

		/// <summary>
		/// Gets the image by GUID.
		/// </summary>
		/// <returns>The image by GUID.</returns>
		/// <param name="imageGuid">Image GUID.</param>
		Image GetImageByGuid(Guid imageGuid);

		/// <summary>
		/// Gets the image by email.
		/// </summary>
		/// <returns>The image by email.</returns>
		/// <param name="email">Email.</param>
		Image GetImageByEmail(string email);

		/// <summary>
		/// Updates the image.
		/// </summary>
		/// <param name="image">Image.</param>
		void UpdateImage(Image image);
    }
}
