using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Core.Repositories.Base;
using YouTubeSearch.Infrastructure.Data;

namespace YouTubeSearch.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext _videoContext;
        public Repository(DatabaseContext videoContext)
        {
            _videoContext = videoContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _videoContext.Set<T>().AddAsync(entity);
            await _videoContext.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(T entity)
        {
            _videoContext.Set<T>().Remove(entity);
            await _videoContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _videoContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await _videoContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
