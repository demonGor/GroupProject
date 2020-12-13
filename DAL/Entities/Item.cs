using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(EntitiesConstants.Item.TitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(EntitiesConstants.Item.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public decimal StartingPrice { get; set; }

        [Required]
        public decimal MinIncrease { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


        
        public int? UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
        public string Image { get; set; }
       
        public Item()
        {
           
            Bids = new List<Bid>();
        }
    }
}
