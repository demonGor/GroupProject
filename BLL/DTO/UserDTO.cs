using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(EntitiesConstants.AuctionUser.FullNameMaxLength)]
        public string Name { get; set; }
        
    }
}
