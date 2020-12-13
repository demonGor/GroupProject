using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
   public interface IRepository<TEntity> where TEntity : class
    {

        void Create(TEntity item);

        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Func<TEntity, bool> predicate);

        void Delete(int id);

        void Update(TEntity item);

    }

}
