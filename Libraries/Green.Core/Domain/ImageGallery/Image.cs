using System;
using Green.Core.Domain.Users;

namespace Green.Core.Domain.ImageGallery
{
    public class Image:BaseEntity
    {
        public Image()
        {
  
        }

        /// <summary>
        /// Gets or sets the image owner identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public int OwnerUserId
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the name of the image.
        /// </summary>
        /// <value>The name of the image.</value>
        public string ImageName
        {
            get;
            set;
        }

        #region Navigation properties

        /// <summary>
        /// Gets or sets the image owner.
        /// </summary>
        /// <value>The owner.</value>
        public User Owner
        {
            get;
            set;
        }

        #endregion

    }
}
