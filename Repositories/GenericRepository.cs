using AutoMapper;
using ECommerceBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace ECommerceBackend.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ECommerceMicroserviceContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ECommerceMicroserviceContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T?>> GetAll() => await _dbSet.ToListAsync();

        public async Task<T?> GetById(int id) => await _dbSet.FindAsync(id);

        public async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
