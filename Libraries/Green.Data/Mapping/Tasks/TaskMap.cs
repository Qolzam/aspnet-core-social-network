using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Green.Core.Domain.Tasks;

namespace Green.Data.Mapping.Tasks
{
	public class PostMap : IEntityTypeConfiguration<ScheduleTask>
	{

		public void Configure(EntityTypeBuilder<ScheduleTask> builder)
		{
			builder.ToTable("ScheduleTask");
			builder.HasKey(t => t.Id);
			builder.Property(t => t.Name).IsRequired();
			builder.Property(t => t.Type).IsRequired();
		}
	}
}


