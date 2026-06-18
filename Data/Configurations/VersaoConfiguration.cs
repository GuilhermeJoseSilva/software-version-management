using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftwareManagement.Domain;

namespace SoftwareManagement.Data.Configurations;

public class VersaoConfiguration : IEntityTypeConfiguration<Versao>
{
    public void Configure(EntityTypeBuilder<Versao> builder)
    {
        builder.HasKey(v => v.IdVersao);

        builder.Property(v => v.Descricao).IsRequired().HasMaxLength(100);

        builder.Property(v => v.Depreciado).IsRequired();

        builder.Property(v => v.DataRelease).IsRequired();

        builder.Property(v => v.SoftwareId).IsRequired();

        builder.HasOne<Software>().WithMany().HasForeignKey(v => v.SoftwareId).OnDelete(DeleteBehavior.Cascade);
    }
}