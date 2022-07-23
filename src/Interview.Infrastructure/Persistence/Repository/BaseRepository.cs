using Interview.Core.Entities;
using Interview.Core.Interfaces.Repository;
using Interview.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Interview.Infrastructure.Persistence.Repository
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : BaseEntity
    {
        protected readonly InterviewDbContext _interviewDbContext;
        public BaseRepository(InterviewDbContext rocsContext)
        {
            _interviewDbContext = rocsContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _interviewDbContext.Set<T>().AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _interviewDbContext.Set<T>();

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            return await query.AsNoTracking().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.Created();
            await _interviewDbContext.Set<T>().AddAsync(entity);
            await _interviewDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.Updated();
            _interviewDbContext.Entry(entity).State = EntityState.Modified;
            _interviewDbContext.AddRange(entity);
            await _interviewDbContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _interviewDbContext.Set<T>().Remove(entity);
            await _interviewDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _interviewDbContext.Dispose();
        }
    }
}
