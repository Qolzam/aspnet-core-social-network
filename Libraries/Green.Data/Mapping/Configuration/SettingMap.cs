using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Green.Core.Domain.Configuration;

namespace Green.Data.Mapping.Configuration
{
	public class SettingMap : IEntityTypeConfiguration<Setting>
	{

		public void Configure(EntityTypeBuilder<Setting> builder)
		{
			builder.ToTable("Setting");
			builder.HasKey(s => s.Id);
			builder.Property(s => s.Name).IsRequired().HasMaxLength(200);
			builder.Property(s => s.Value).IsRequired().HasMaxLength(2000);

		
		}
	}
}
