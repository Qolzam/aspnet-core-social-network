using System;
using System.Collections.Generic;
using System.Linq;
using Green.Core.Data;
using Green.Core.Domain.ImageGallery;

namespace Green.Services.ImageGallery
{
    public class ImageService
    {
		#region Fields

		private readonly IRepository<Image> _imageRepository;

		#endregion

		#region Constructor


		/// <summary>
		/// Initializes a new instance of the <see cref="T:Green.Services.Images.ImageService"/> class.
		/// </summary>
		/// <param name="imageRepository">Image repository.</param>
		public ImageService(IRepository<Image> imageRepository)
		{
			this._imageRepository = imageRepository;
		}

		#endregion

		#region Methods

		/// <summary>
		/// Inserts the image.
		/// </summary>
		/// <param name="image">Image.</param>
		public void InsertImage(Image image)
		{
			if (image == null)
				throw new ArgumentNullException(nameof(image));


			_imageRepository.Insert(image);
		}

		/// <summary>
		/// Gets all images.
		/// </summary>
		/// <returns>The all images.</returns>
		public IList<Image> GetAllImages()
		{
			return _imageRepository.Table.ToList();
		}

		/// <summary>
		/// Gets the image by identifier.
		/// </summary>
		/// <returns>The image by identifier.</returns>
		/// <param name="imageId">Image identifier.</param>
		public Image GetImageById(int imageId)
		{
			if (imageId == 0)
				return null;

			return _imageRepository.GetById(imageId);
		}

		/// <summary>
		/// Gets the image by GUID.
		/// </summary>
		/// <returns>The image by GUID.</returns>
		/// <param name="imageGuid">Image GUID.</param>
		public Image GetImageByGuid(Guid imageGuid)
		{
			if (imageGuid == Guid.Empty)
				return null;

			var query = from im in _imageRepository.Table
						where im.Key == imageGuid
						orderby im.Id
						select im;
			var image = query.FirstOrDefault();

			return image;
		}

		/// <summary>
		/// Updates the image.
		/// </summary>
		/// <param name="image">Image.</param>
		public void UpdateImage(Image image)
		{
			if (image == null)
				throw new ArgumentNullException(nameof(image));

			_imageRepository.Update(image);
		}


		#endregion
	}
}
