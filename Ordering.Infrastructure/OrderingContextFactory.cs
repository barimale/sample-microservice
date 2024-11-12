using Microsoft.EntityFrameworkCore.Design;

namespace Ordering.Infrastructure
{
    /* For migrations generation only */

    public class OrderingContextFactory : IDesignTimeDbContextFactory<OrderingContext>
    {
        public OrderingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OrderingContext>();
            optionsBuilder.UseSqlServer("Data Source=MATEUSZ;Initial Catalog=DataBaseName;TrustServerCertificate=True;Integrated Security=True;");

            return new OrderingContext(optionsBuilder.Options);
        }
    }
}