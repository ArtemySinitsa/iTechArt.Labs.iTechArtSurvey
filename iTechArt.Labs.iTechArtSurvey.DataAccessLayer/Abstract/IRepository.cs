using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> FindAsync(int id);
        void UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
    }
}
