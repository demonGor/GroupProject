using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICategoryService:IDisposable
    {
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task CreateAsync(CategoryDTO category);
        Task<CategoryDTO> GetByIdAsync(int id);
    }
}
