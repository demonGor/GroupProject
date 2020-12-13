using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBidService : IDisposable
    {
        Task CreateAsync(BidDTO model);

        Task<BidDTO> GetHighestBidAmountForGivenItemAsync(int id);

       
    }
}
