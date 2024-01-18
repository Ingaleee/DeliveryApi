using DeliveryApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeliveryApi.Services
{
    public class DomainProvider : IDomainProvider
    {
        private readonly ApplicationContext _context;

        public DomainProvider(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ICollection<TEntity>> GetAllAsync<TEntity>() where TEntity : class, IHasId
        {
            var set = _context.Set<TEntity>();
            var entities = await set.ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(ulong id) where TEntity : class, IHasId
        {
            if (id == 0)
            {
                throw new ArgumentException(null, nameof(id));
            }

            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<ulong> AddAsync<TEntity>(TEntity entity) where TEntity : class, IHasId
        {
            if (entity == null)
            {
                throw new ArgumentException(null, nameof(TEntity));
            }
            var newEntity = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity.Id;
        }
    }
}
