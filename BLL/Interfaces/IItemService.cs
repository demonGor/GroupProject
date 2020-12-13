using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IItemService : IDisposable
    {
        Task<ItemDTO> GetByIdAsync(int id);
        Task<IEnumerable<ItemDTO>> GetAllLiveItemsAsync();
        Task<IEnumerable<ItemDTO>> GetAllItemsForGivenUserAsync(int userId);
        Task CreateAsync(ItemDTO item);
        Task<IEnumerable<ItemDTO>> GetAllItemsInGivenCategoryByCategoryIdAsync(int id);
        Task<IEnumerable<ItemDTO>> GetAllItemsAsync();
        Task<IEnumerable<ItemDTO>> SearchByTitleAsync(string query);
        Task DeleteAsync(int id);
        Task UpdateAsync(ItemDTO item);
    }
}
