using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
 public interface IUnitOfWork:IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Bid> Bids { get; }
        IRepository<Category> Categories { get; }
        IRepository<Item> Items { get; }
        void Save();
        Task SaveAsync();

    }
}
