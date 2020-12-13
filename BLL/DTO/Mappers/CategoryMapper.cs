using BLL.DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Mappers
{
   public static class CategoryMapper
    {
        public static CategoryDTO MapToDTO(Category obj)
        {
            return new CategoryDTO
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }
        public static Category MapToEntity(CategoryDTO obj)
        {
            return new Category
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }

    }
}
