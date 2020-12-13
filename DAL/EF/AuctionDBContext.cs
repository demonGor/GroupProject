using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class AuctionDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Bid> Bids { get; set; }    
        public AuctionDBContext(string connectionString) : base(connectionString) { }
        static AuctionDBContext()
        {
            Database.SetInitializer(new AuctionDbInitializer());
        }
        public class AuctionDbInitializer : DropCreateDatabaseIfModelChanges<AuctionDBContext>
        {
            protected override void Seed(AuctionDBContext context)
            {
                var admin = new User { Name = "administrator" };
                var user = new User {  Name = "vasya" };
               

                Category cat1 = new Category { Name = "Електроніка" };
                Category cat2 = new Category { Name = "Антикваріат" };
                Category cat3 = new Category { Name = "Ручні роботи" };
                Item item1 = new Item { Title = "Cтаровинна монета", Description = "Монета минулого сторіччя", StartingPrice = 50, MinIncrease = 2, StartTime =new DateTime(2019, 4, 7), EndTime = new DateTime(2019,6,13), Image = "http://www.graycell.ru/picture/big/soveren.jpghttp://www.graycell.ru/picture/big/soveren.jpg" };
                Item item2 = new Item { Title = "Телевізор", Description = "Просто телевізор ", StartingPrice = 8000, MinIncrease = 100, StartTime = new DateTime(2019, 4, 12) , EndTime = new DateTime(2019, 8, 18), Image = "https://5element.by/upload/runtime/images/59/15/59153226-televizor-led-lg-43uj634v.jpg" };
                Item item3 = new Item { Title = "Вишивка бісером", Description = "Просто дуже красиво ", StartingPrice = 400, MinIncrease = 50, StartTime = new DateTime(2019, 4, 10), EndTime = new DateTime(2019, 8, 25), Image = "https://images.ua.prom.st/641312778_vishivka-biserom-pavlini.jpg" };
                admin.ItemsSold.Add(item2);
                user.ItemsSold.Add(item1);
                user.ItemsSold.Add(item3);
                cat1.Items.Add(item2);
                cat2.Items.Add(item1);
                cat3.Items.Add(item3);
                context.Users.AddRange(new List<User> { admin, user });
                context.Categories.Add(cat1);
                context.Categories.Add(cat2);
                context.Categories.Add(cat3);
                context.SaveChanges();
            }
        }
    }
}
