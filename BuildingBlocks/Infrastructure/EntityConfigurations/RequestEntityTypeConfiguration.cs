using BuildingBlocks.Domain.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ordering.Infrastructure.EntityConfigurations;

public class RequestEntityTypeConfiguration
    : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> buyerConfiguration)
    {
        buyerConfiguration.ToTable("requests");

        buyerConfiguration.Property(b => b.Id);
            //.UseHiLo("buyerseq");

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
