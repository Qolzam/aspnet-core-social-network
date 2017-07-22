using System;
using Green.Core.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Green.Data.Mapping.Posts
{
	public class PostMap : IEntityTypeConfiguration<Post>
	{

		public void Configure(EntityTypeBuilder<Post> builder)
		{
			builder.ToTable("Post");
			builder.HasKey(u => u.Id);

            builder.HasMany(p => p.Comments)
                   .WithOne(c => c.Post)
                   .HasForeignKey(c => c.PostId)
                   .OnDelete(DeleteBehavior.Restrict);
		}
	}
}


