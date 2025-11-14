using Hotel.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Infrastructure.Database.Configurations.Users;

public sealed class RefreshTokenEntityConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
{
    public void Configure(EntityTypeBuilder<RefreshTokenEntity> b)
    {
        b.ToTable("RefreshTokens");

        b.HasKey(x => x.Id);

        b.HasIndex(x => new { x.UserId, x.TokenHash })
            .IsUnique();

        b.Property(x => x.TokenHash)
            .IsRequired();

        b.Property(x => x.ExpiresAtUtc)
            .IsRequired();

        b.Property(x => x.IsRevoked)
            .HasDefaultValue(false);

        b.Property(x => x.Fingerprint)
            .HasMaxLength(200);
    }
}
