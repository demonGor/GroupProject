using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Mappers
{
    public static class ItemMapper
    {
        public static ItemDTO MapToDTO(Item obj)
        {
            return new ItemDTO
            {
                Id = obj.Id,
                Title = obj.Title,
                StartTime = obj.StartTime,
                StartingPrice = obj.StartingPrice,
                Description = obj.Description,
                UserId = obj.UserId,
                EndTime = obj.EndTime,
                MinIncrease = obj.MinIncrease,
                CategoryId = obj.CategoryId,
                Image = obj.Image,
                CategoryName=obj.Category.Name,
                UserName = obj.User.Name

            };
        }
        public static Item MapToEntity(ItemDTO obj)
        {
            return new Item
            {
                Id = obj.Id,
                Title = obj.Title,
                StartTime = obj.StartTime,
                StartingPrice = obj.StartingPrice,
                Description = obj.Description,
                UserId = obj.UserId,
                EndTime = obj.EndTime,
                MinIncrease = obj.MinIncrease,
                CategoryId = obj.CategoryId,
                Image=obj.Image
                
            };
        }
    }
}
