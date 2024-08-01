using BuildingBlocks.Infrastructure;
using Ordering.Domain.AggregatesModel.BuyerAggregate;

namespace Ordering.Infrastructure.EntityConfigurations;

class HttpRequestEntityTypeConfiguration
    : IEntityTypeConfiguration<HttpRequest>
{
    public void Configure(EntityTypeBuilder<HttpRequest> buyerConfiguration)
    {
        buyerConfiguration.ToTable("HttpRequest");

        //buyerConfiguration.Ignore(b => b.DomainEvents);

        buyerConfiguration.Property(b => b.Id);
        //.UseHiLo("buyerseq");

        buyerConfiguration.Property(b => b.Header);
        //.HasMaxLength(200);
        buyerConfiguration.Property(b => b.Body);
        buyerConfiguration.Property(b => b.executionTime);

        buyerConfiguration.HasIndex("IdentityGuid")
            .IsUnique(true);
    }
}
