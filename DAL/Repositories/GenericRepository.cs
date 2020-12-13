using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
   public class GenericRepository<T> :IRepository<T> where T:class

    {
        AuctionDBContext _context;
        public GenericRepository(AuctionDBContext context)
        {
            if(context==null)
                throw new ArgumentNullException(nameof(context));
            _context = context;
          
        }

        public void Create(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(int id)
        {
            T item = _context.Set<T>().Find(id);
            if (item != null)
                _context.Set<T>().Remove(item);
        }

        public async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        {
            Task<IEnumerable<T>> task = Task.Run(() => _context.Set<T>().AsNoTracking().Where(predicate));
            return await task;
        }

        public async Task<T> GetAsync(int id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }
        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this._context.Set<T>().ToListAsync();
        }
        public IEnumerable<T> GetAll()
        {
            return  this._context.Set<T>().ToList();
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }
    }
}
