using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);
        Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
