using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BidDTO
    {
        
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public int UserId { get; set; }
        public string UserName { get; set; }
        [Required]
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }
        
        public DateTime MadeOn { get; set; }
    }

}
