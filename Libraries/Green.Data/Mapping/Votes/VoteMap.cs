using System;
using Green.Core.Domain.Votes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Green.Data.Mapping.Votes
{
	public class VoteMap : IEntityTypeConfiguration<Vote>
	{

		public void Configure(EntityTypeBuilder<Vote> builder)
		{
			builder.ToTable("Vote");
            builder.HasKey(v => new {v.PostId ,v.VoterId });

			builder.HasOne(v => v.Post)
                   .WithMany(p => p.Votes)
                   .HasForeignKey(v => v.PostId)
                   .OnDelete(DeleteBehavior.Restrict);

			builder.HasOne(v => v.Voter)
				  .WithMany(u => u.Votes)
                   .HasForeignKey(v => v.VoterId)
                   .OnDelete(DeleteBehavior.Restrict);

		}
	}
}
