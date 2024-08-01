using BuildingBlocks.Infrastructure;
using Ordering.Domain.AggregatesModel.BuyerAggregate;

namespace Ordering.Infrastructure.EntityConfigurations;

class HttpResponseEntityTypeConfiguration
    : IEntityTypeConfiguration<HttpResponse>
{
    public void Configure(EntityTypeBuilder<HttpResponse> buyerConfiguration)
    {
        buyerConfiguration.ToTable("HttpResponse");

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
