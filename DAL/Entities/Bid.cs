using Common;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Bid
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }


        [Required]
        public  int UserId { get; set; }

        public virtual User User { get; set; }


        [Required]
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

       
        public DateTime MadeOn { get; set; }
    }
}

