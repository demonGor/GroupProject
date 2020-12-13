using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface IUserService:IDisposable

    {
        Task CreateAsync(UserDTO user);
        Task DeleteAsync(int id);
        Task<IEnumerable<UserDTO>> GetAllAsync();
        Task<UserDTO> FindByIdAsync(int id);
        Task<UserDTO> FindByNameAsync(string name);


    }
}
