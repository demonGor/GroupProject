using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoSContainers
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBidService>().To<BidService>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IItemService>().To<ItemService>();
            Bind<IUserService>().To<UserService>();

        }
    }

}
