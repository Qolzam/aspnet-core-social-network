using System;
using Green.Core.Domain.Circles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Green.Data.Mapping.Circles
{
	public class CircleMap : IEntityTypeConfiguration<Circle>
	{

		public void Configure(EntityTypeBuilder<Circle> builder)
		{
			builder.ToTable("Circle");
			builder.HasKey(u => u.Id);


		}
	}
}
