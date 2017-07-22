using System;
using Green.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Green.Data.Mapping
{
    public class UserMap:IEntityTypeConfiguration<User>
    {
 
        public void Configure(EntityTypeBuilder<User> builder)
        {
		    builder.ToTable("User");
			builder.HasKey(u => u.Id);
			builder.Property(u => u.UserName).HasMaxLength(1000);
			builder.Property(u => u.Email).HasMaxLength(1000);

            builder.HasMany(u => u.Images)
                   .WithOne(i => i.Owner)
                   .HasForeignKey(i => i.OwnerUserId);

            builder.HasMany(u => u.Posts)
                   .WithOne(p => p.Owner)
                   .HasForeignKey(p => p.OwnerUserId);

            builder.HasMany(u => u.Notifies)
                   .WithOne(n => n.User)
                   .HasForeignKey(n => n.UserId);
		}
    }
}
