using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ClientDashboardAPI.Models;

public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
    public void Configure(EntityTypeBuilder<PhoneNumber> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(c => c.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.FormattedNumber).IsRequired();
        builder.Property<string>("_rawPhoneNumber")
            .HasColumnName("RawPhoneNumber");

        builder.HasOne(p => p.Client)
           .WithMany(c => c.PhoneNumbers)
           .HasForeignKey(p => p.ClientId)
           .OnDelete(DeleteBehavior.Cascade);

        //Data Seeding
        builder.HasData(
        new PhoneNumber { Id = 1, FormattedNumber = "(516) 913-4354", ClientId = 1 },
        new PhoneNumber { Id = 2, FormattedNumber = "(810) 810-5096", ClientId = 1 },
        new PhoneNumber { Id = 3, FormattedNumber = "(309) 786-8003", ClientId = 1 },
        new PhoneNumber { Id = 4, FormattedNumber = "(215) 633-2089", ClientId = 1 },
        new PhoneNumber { Id = 5, FormattedNumber = "(746) 731-8429", ClientId = 2 },
        new PhoneNumber { Id = 6, FormattedNumber = "(238) 886-1541", ClientId = 2 },
        new PhoneNumber { Id = 7, FormattedNumber = "(956) 415-9515", ClientId = 3 },
        new PhoneNumber { Id = 8, FormattedNumber = "(694) 136-9631", ClientId = 3 },
        new PhoneNumber { Id = 9, FormattedNumber = "(133) 313-2881", ClientId = 6 },
        new PhoneNumber { Id = 10, FormattedNumber = "(192) 843-1901", ClientId = 6 },
        new PhoneNumber { Id = 11, FormattedNumber = "(274) 443-6658", ClientId = 6 },
        new PhoneNumber { Id = 12, FormattedNumber = "(220) 407-6727", ClientId = 8 },
        new PhoneNumber { Id = 13, FormattedNumber = "(222) 575-6115", ClientId = 10 },
        new PhoneNumber { Id = 14, FormattedNumber = "(530) 481-9521", ClientId = 11 },
        new PhoneNumber { Id = 15, FormattedNumber = "(804) 841-3297", ClientId = 11 },
        new PhoneNumber { Id = 16, FormattedNumber = "(673) 997-5545", ClientId = 11 },
        new PhoneNumber { Id = 17, FormattedNumber = "(292) 796-3892", ClientId = 12 },
        new PhoneNumber { Id = 18, FormattedNumber = "(831) 493-1097", ClientId = 12 },
        new PhoneNumber { Id = 19, FormattedNumber = "(621) 633-6470", ClientId = 14 },
        new PhoneNumber { Id = 20, FormattedNumber = "(482) 221-5583", ClientId = 14 },
        new PhoneNumber { Id = 21, FormattedNumber = "(542) 877-4014", ClientId = 14 },
        new PhoneNumber { Id = 22, FormattedNumber = "(430) 224-7502", ClientId = 15 },
        new PhoneNumber { Id = 23, FormattedNumber = "(287) 676-4409", ClientId = 15 },
        new PhoneNumber { Id = 24, FormattedNumber = "(170) 285-2523", ClientId = 17 },
        new PhoneNumber { Id = 25, FormattedNumber = "(984) 522-6675", ClientId = 18 },
        new PhoneNumber { Id = 26, FormattedNumber = "(132) 816-5431", ClientId = 20 },
        new PhoneNumber { Id = 27, FormattedNumber = "(768) 577-3949", ClientId = 20 },
        new PhoneNumber { Id = 28, FormattedNumber = "(262) 456-6803", ClientId = 20 },
        new PhoneNumber { Id = 29, FormattedNumber = "(886) 379-3203", ClientId = 20 }
    );
    }
}