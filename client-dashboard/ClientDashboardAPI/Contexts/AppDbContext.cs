using Microsoft.EntityFrameworkCore;
using ClientDashboardAPI.Models;

public class AppDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new PhoneNumberConfiguration());
    }
}