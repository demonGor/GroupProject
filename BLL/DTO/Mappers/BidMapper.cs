using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Mappers
{
  public static class BidMapper
    {
        public static BidDTO  MapToDTO(Bid obj)
        {
            return new BidDTO
            {
                Id = obj.Id,
                ItemId = obj.ItemId,
                Amount = obj.Amount,
                MadeOn = obj.MadeOn,
                UserId = obj.UserId,
                UserName=obj.User.Name,
                ItemTitle=obj.Item.Title
            };
        }
        public static Bid MapToEntity(BidDTO obj)
        {
            return new Bid
            {
                Id=obj.Id,
                ItemId = obj.ItemId,
                Amount = obj.Amount,
                MadeOn = obj.MadeOn,
                UserId = obj.UserId
            };
        }


    }
}
