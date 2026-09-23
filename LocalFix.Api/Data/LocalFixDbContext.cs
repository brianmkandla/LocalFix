using Microsoft.EntityFrameworkCore;
using LocalFix.Api.Models;

namespace LocalFix.Api.Data;

public class LocalFixDbContext : DbContext
{
    public LocalFixDbContext(DbContextOptions<LocalFixDbContext> options) : base(options)
    {
        
    }

    public DbSet<ServiceRequest>  ServiceRequests { get; set; }

    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    {
        ModelBuilder.Entity<ServiceRequest>(entity => 
        {
           entity.ToTable("ServiceRequests"); // table name

           entity.HasKey(r => r.Id); // primary key

           entity.Property(r => r.Id)
                 .HasColumnName("RequestID");
        });
    }
    
}