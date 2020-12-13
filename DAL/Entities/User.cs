using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(EntitiesConstants.AuctionUser.FullNameMaxLength)]
        public string Name { get; set; }

        public  virtual ICollection<Item> ItemsSold { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        public User()
        {
            ItemsSold = new List<Item>();
            Bids = new List<Bid>();
        }
    }
}
