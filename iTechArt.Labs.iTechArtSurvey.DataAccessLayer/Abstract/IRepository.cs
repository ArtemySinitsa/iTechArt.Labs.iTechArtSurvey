using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Labs.iTechArtSurvey.DataAccessLayer.Abstract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ICollection<TEntity> GetAll();
        TEntity Create(TEntity entity);
        TEntity Find(int id);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
