using Microsoft.EntityFrameworkCore;
using LocalFix.Api.Models;

namespace LocalFix.Api.Data;

public class LocalFixDbContext : DbContext
{
    public LocalFixDbContext(DbContextOptions<LocalFixDbContext> options) : base(options)
    {
        
    }

    public DbSet<ServiceRequest>  ServiceRequests { get; set; }
}