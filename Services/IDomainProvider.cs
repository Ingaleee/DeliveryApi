using DeliveryApi.Types;

namespace DeliveryApi.Services
{
    public interface IDomainProvider
    {
        Task<ICollection<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IHasId;
        Task<TEntity> GetByIdAsync<TEntity>(ulong id) where TEntity : class, IHasId;
        Task<ulong> AddAsync<TEntity>(TEntity entity) where TEntity : class, IHasId;
    }
}
