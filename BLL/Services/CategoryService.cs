using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Interfaces;
using BLL.DTO.Mappers;
using DAL;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {

        private IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CategoryDTO category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _unitOfWork.Categories.Create(CategoryMapper.MapToEntity(category));
            await _unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            return (await _unitOfWork.Categories.GetAllAsync()).Select(u => CategoryMapper.MapToDTO(u));
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            Category res = await _unitOfWork.Categories.GetAsync(id);
            if (res == null)
                return null;
            return CategoryMapper.MapToDTO(res);
        }
    }
}
