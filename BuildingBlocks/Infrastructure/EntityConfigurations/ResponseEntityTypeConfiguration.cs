using BuildingBlocks.Domain.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ordering.Infrastructure.EntityConfigurations;

public class ResponseEntityTypeConfiguration
    : IEntityTypeConfiguration<Response>
{
    public void Configure(EntityTypeBuilder<Response> buyerConfiguration)
    {
        buyerConfiguration.ToTable("responses");

        buyerConfiguration.Property(b => b.Id);

        buyerConfiguration.Property(b => b.CorrelationId)
            .HasMaxLength(200);

        buyerConfiguration.Property(b => b.Content)
            .HasMaxLength(int.MaxValue);

        buyerConfiguration.Property(b => b.ExecutionTime)
            .HasConversion<DateTimeOffset>();

        buyerConfiguration.HasIndex("CorrelationId")
            .IsUnique(true);
    }
}
