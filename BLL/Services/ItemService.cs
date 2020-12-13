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
    public class ItemService : IItemService
    {

        private IUnitOfWork _unitOfWork;
        public ItemService(IUnitOfWork unitOfWork)
        {

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(ItemDTO item)
        {

            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _unitOfWork.Items.Create(ItemMapper.MapToEntity(item));
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Items.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItemsAsync()
        {
            
            return (await _unitOfWork.Items.GetAllAsync()).Select(u => ItemMapper.MapToDTO(u)); 
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItemsForGivenUserAsync(int userId)
        {
           
            return (await _unitOfWork.Items.FindAsync(x => x.UserId == userId)).Select(u => ItemMapper.MapToDTO(u));
        }

        public async Task<IEnumerable<ItemDTO>> GetAllItemsInGivenCategoryByCategoryIdAsync(int id)
        {
           
            return (await _unitOfWork.Items.FindAsync(x => x.CategoryId == id)).Select(u => ItemMapper.MapToDTO(u));
        }

        public async Task<IEnumerable<ItemDTO>> GetAllLiveItemsAsync()
        {
            return (await _unitOfWork.Items.FindAsync(x => x.StartTime <= DateTime.Now && x.EndTime >= DateTime.Now)).Select(u => ItemMapper.MapToDTO(u));
        }

        public async Task<ItemDTO> GetByIdAsync(int id)
        {
            Item res = await _unitOfWork.Items.GetAsync(id);
            if (res == null)
                return null;
            return ItemMapper.MapToDTO(res);
        }

       

        public async Task<IEnumerable<ItemDTO>> SearchByTitleAsync(string query)
        {
            return (await _unitOfWork.Items.FindAsync(x => x.Title.Contains(query))).Select(u => ItemMapper.MapToDTO(u));
        }

        public async Task UpdateAsync(ItemDTO item)
        {
            if (item == null)
                throw new ArgumentNullException();
            Item Item = await _unitOfWork.Items.GetAsync(item.Id);
            if (Item == null)
                throw new ArgumentNullException();
            Item.CategoryId = item.CategoryId;
            Item.Description = item.Description;
            Item.EndTime = item.EndTime;
            Item.Image = item.Image;
            Item.MinIncrease = item.MinIncrease;
            Item.StartingPrice = item.StartingPrice;
            Item.StartTime = item.StartTime;
            Item.Title = item.Title;
            _unitOfWork.Items.Update(Item);
            await _unitOfWork.SaveAsync();
        }
    }
}
