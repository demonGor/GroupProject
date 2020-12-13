using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.Mappers
{
  public static  class UserMapper
    {
        public static UserDTO MapToDTO(User obj)
        {
            return new UserDTO
            {
                Id = obj.Id,
                Name = obj.Name

            };
        }
        public static User MapToEntity(UserDTO obj)
        {
            return new User
            {
                Id = obj.Id,
                Name = obj.Name
            };
        }
    }
}
