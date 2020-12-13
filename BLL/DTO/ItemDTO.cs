using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
  public  class ItemDTO
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
        public string CategoryName { get; set; }
        public string Image { get; set; }
        
        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
}
