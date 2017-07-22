using System;
using Green.Core.Domain.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Green.Data.Mapping.Commnets
{
	public class CommentMap : IEntityTypeConfiguration<Comment>
	{

		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.ToTable("Comment");
			builder.HasKey(u => u.Id);

		
		}
	}
}
