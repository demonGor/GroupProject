using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(EntitiesConstants.Category.NameMaxLength)]
        public string Name { get; set; }
    }
}
