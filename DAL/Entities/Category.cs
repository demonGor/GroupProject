using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(EntitiesConstants.Category.NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        public Category()
        {
            Items = new List<Item>();
         
        }
    }
}
