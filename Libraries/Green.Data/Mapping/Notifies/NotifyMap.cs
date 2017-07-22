using System;
using Green.Core.Domain.Notifies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Green.Data.Mapping.Notifies
{
    public class NotifyMap : IEntityTypeConfiguration<Notify>
	{

		public void Configure(EntityTypeBuilder<Notify> builder)
		{
			builder.ToTable("Notify");
			builder.HasKey(u => u.Id);


		}
	}
}
