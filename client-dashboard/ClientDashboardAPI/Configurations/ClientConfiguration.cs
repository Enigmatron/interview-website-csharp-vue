using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClientDashboardAPI.Models;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Active).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(255).IsRequired(false);
        builder.Property(c => c.Address).HasMaxLength(255).IsRequired(false);
        builder.Property(c => c.Company).HasMaxLength(255).IsRequired(false);
        builder.HasMany(c => c.PhoneNumbers)
               .WithOne(p => p.Client)
               .HasForeignKey(p => p.ClientId)
               .OnDelete(DeleteBehavior.Cascade);


        //Data Seeding
        builder.HasData(
            new Client { Id = 1, Name = "Test Client", Email = "test@example.com", Company = "TestCo", Address = "123 Test Ave", Active = true },
            new Client { Id = 2, Name = "Second Client", Email = "second@example.com", Company = "SecondCo", Address = "456 Sample Blvd", Active = true },
            new Client { Id = 3, Name = "Alpha Inc", Email = "contact@alpha.com", Company = "Alpha Inc", Address = "1 Alpha Way", Active = true },
            new Client { Id = 4, Name = "Beta Corp", Email = "info@beta.com", Company = "Beta Corporation", Address = "42 Beta St", Active = false },
            new Client { Id = 5, Name = "Gamma LLC", Email = "support@gamma.com", Company = "Gamma LLC", Address = "99 Gamma Circle", Active = true },
            new Client { Id = 6, Name = "Delta Co", Email = "hello@delta.com", Company = "Delta Co", Address = "67 Delta Rd", Active = false },
            new Client { Id = 7, Name = "Epsilon Ltd", Email = "office@epsilon.com", Company = "Epsilon Ltd", Address = "8 Epsilon Pkwy", Active = true },
            new Client { Id = 8, Name = "Zeta Group", Email = "zeta@group.org", Company = "Zeta Group", Address = "77 Zeta Ln", Active = true },
            new Client { Id = 9, Name = "Eta Agency", Email = "contact@etaagency.com", Company = "Eta Agency", Address = "34 Eta Dr", Active = false },
            new Client { Id = 10, Name = "Theta Enterprises", Email = "theta@enterprises.net", Company = "Theta Enterprises", Address = "12 Theta Ct", Active = true },
            new Client { Id = 11, Name = "Iota Partners", Email = "info@iotapartners.com", Company = "Iota Partners", Address = "90 Iota Cres", Active = true },
            new Client { Id = 12, Name = "Kappa Services", Email = "admin@kappaservices.com", Company = "Kappa Services", Address = "4 Kappa Blvd", Active = false },
            new Client { Id = 13, Name = "Lambda Systems", Email = "lambda@systems.biz", Company = "Lambda Systems", Address = "6 Lambda St", Active = true },
            new Client { Id = 14, Name = "Mu Logistics", Email = "mu@logistics.org", Company = "Mu Logistics", Address = "22 Mu Rd", Active = true },
            new Client { Id = 15, Name = "Nu Technologies", Email = "team@nu.tech", Company = "Nu Technologies", Address = "100 Nu Tech Dr", Active = false },
            new Client { Id = 16, Name = "Xi Solutions", Email = "xi@solutions.dev", Company = "Xi Solutions", Address = "59 Xi Ave", Active = true },
            new Client { Id = 17, Name = "Omicron Industries", Email = "omicron@industries.net", Company = "Omicron Industries", Address = "14 Omicron Way", Active = true },
            new Client { Id = 18, Name = "Pi Innovations", Email = "hello@piinnovations.com", Company = "Pi Innovations", Address = "88 Pi Park", Active = true },
            new Client { Id = 19, Name = "Rho Labs", Email = "rho@labs.tech", Company = "Rho Labs", Address = "21 Rho Dr", Active = true },
            new Client { Id = 20, Name = "Sigma Ventures", Email = "sigma@ventures.io", Company = "Sigma Ventures", Address = "5 Sigma Ln", Active = true }
        );
    }
}