using Microsoft.EntityFrameworkCore;
using SoftwareManagement.Domain;

namespace SoftwareManagement.Data;

public class AppDbContext : DbContext
{
    public AppDbContext (DbContextOptions<AppDbContext> options): base(options) { }
    
    public DbSet<Software> Softwares { get; set; }
    public DbSet<Versao> Versoes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

}