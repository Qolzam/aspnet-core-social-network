using System;
using Green.Core.Domain.Circles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Green.Data.Mapping.Circles
{
	public class NotifyMap : IEntityTypeConfiguration<UserCircle>
	{

		public void Configure(EntityTypeBuilder<UserCircle> builder)
		{
			builder.ToTable("UserCircle");
            builder.HasKey(uc => new {uc.CircleId, uc.UserId});

            builder.HasOne(uc => uc.Circle)
                   .WithMany(c => c.UserCircles)
                   .HasForeignKey(uc => uc.CircleId);
            
			builder.HasOne(uc => uc.User)
				  .WithMany(c => c.UserCircles)
                   .HasForeignKey(uc => uc.UserId);

		}
	}
}

