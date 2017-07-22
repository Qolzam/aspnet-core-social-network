using System;

namespace Green.Core
{
	/// <summary>
	/// Base class for entities
	/// </summary>
	public abstract partial class BaseEntity
	{

        public BaseEntity()
        {
			this.Key = Guid.NewGuid();
            this.CreatedOnUtc = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        public Guid Key
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the created on UTC.
        /// </summary>
        /// <value>The created on UTC.</value>
        public DateTime CreatedOnUtc
        {
            get;
            set;
        }

        public override bool Equals(object obj)
		{
			return Equals(obj as BaseEntity);
		}

		private static bool IsTransient(BaseEntity obj)
		{
			return obj != null && Equals(obj.Id, default(int));
		}

		private Type GetUnproxiedType()
		{
			return GetType();
		}

		public virtual bool Equals(BaseEntity other)
		{
			if (other == null)
				return false;

			if (ReferenceEquals(this, other))
				return true;

			if (!IsTransient(this) &&
				!IsTransient(other) &&
				Equals(Id, other.Id))
			{
				var otherType = other.GetUnproxiedType();
				var thisType = GetUnproxiedType();
				return thisType.IsAssignableFrom(otherType) ||
						otherType.IsAssignableFrom(thisType);
			}

			return false;
		}

		public override int GetHashCode()
		{
			if (Equals(Id, default(int)))
				return base.GetHashCode();
			return Id.GetHashCode();
		}

		public static bool operator ==(BaseEntity x, BaseEntity y)
		{
			return Equals(x, y);
		}

		public static bool operator !=(BaseEntity x, BaseEntity y)
		{
			return !(x == y);
		}
	}
}