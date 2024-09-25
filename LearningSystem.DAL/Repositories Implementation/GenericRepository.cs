using LearningSystem.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.DAL
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly LearningPlatformContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(LearningPlatformContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new InvalidOperationException("Entity not found.");
                }

                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Handle concurrency exception
                Console.WriteLine("Concurrency conflict occurred: " + ex.Message);
                throw;
            }
        }


        public async Task<int> NumberOfEntitiesAsync()
        {
            return await _dbSet.CountAsync();
        }
    }

}
