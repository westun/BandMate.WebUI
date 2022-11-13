using BandMate.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BandMate.Domain.Persistence.EntityConfigurations
{
    public class PasswordResetRequestConfiguration : IEntityTypeConfiguration<PasswordResetRequest>
    {
        public void Configure(EntityTypeBuilder<PasswordResetRequest> builder)
        {
            builder.HasKey(p => p.PasswordResetRequestID);
            
            builder.Property(e => e.Token)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");
                        
            builder.HasIndex(e => e.Token);
       }
    }
}