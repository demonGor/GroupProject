using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
   public class UnitOfWork:IUnitOfWork
    {
        private AuctionDBContext db;
        private GenericRepository<User> usersRepository;
        private GenericRepository<Bid> bidsRepository;
        private GenericRepository<Item> itemsRepository;
        private GenericRepository<Category> categoriesRepository;
        
        
       
        public UnitOfWork(string connectionString)
        {
            db = new AuctionDBContext(connectionString);
            bidsRepository = new GenericRepository<Bid>(db);
            categoriesRepository = new GenericRepository<Category>(db);
            itemsRepository = new GenericRepository<Item>(db);
            usersRepository = new GenericRepository<User>(db);
        }

        public IRepository<Bid> Bids
        {
            get
            {
                return bidsRepository;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                return usersRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                return categoriesRepository;
            }
        }

        public IRepository<Item> Items
        {
            get
            {
                return itemsRepository;
            }
        }

      
       
      

        public void Save()
        {
            db.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



    }
}
