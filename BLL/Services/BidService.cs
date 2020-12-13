using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Interfaces;
using BLL.DTO.Mappers;

namespace BLL.Services
{
    public class BidService : IBidService
    {
        private IUnitOfWork _unitOfWork;
        public BidService(IUnitOfWork unitOfWork)
        {

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWork = unitOfWork;
        }
     

        public async Task CreateAsync(BidDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            model.MadeOn=DateTime.Now;
            _unitOfWork.Bids.Create(BidMapper.MapToEntity(model));
            await _unitOfWork.SaveAsync();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<BidDTO> GetHighestBidAmountForGivenItemAsync(int id)
        {

            var res=(await _unitOfWork.Bids.FindAsync(x => x.ItemId == id)).OrderByDescending(x => x.Amount).FirstOrDefault();
            if (res == null)
                return null;
            return BidMapper.MapToDTO(res);
        }
    }
}
