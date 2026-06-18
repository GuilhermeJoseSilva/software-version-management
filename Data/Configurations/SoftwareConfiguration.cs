using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareManagement.Domain;

namespace SoftwareManagement.Data.Configurations;

public class SoftwareConfiguration : IEntityTypeConfiguration<Software>
{
    public void Configure(EntityTypeBuilder<Software> builder)
    {
        builder.HasKey(s => s.IdSoftware);

        builder.Property(s => s.Nome).IsRequired().HasMaxLength(150);

        builder.Property(s => s.Fornecedor).IsRequired().HasMaxLength(150);

    }
}