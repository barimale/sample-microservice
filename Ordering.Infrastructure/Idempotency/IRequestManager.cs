using System;
using System.Threading.Tasks;

namespace eShop.Ordering.Infrastructure.Idempotency;

public interface IRequestManager
{
    Task<bool> ExistAsync(Guid id);

    Task CreateRequestForCommandAsync<T>(Guid id);
}
