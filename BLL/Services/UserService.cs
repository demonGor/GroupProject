using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using DAL.Interfaces;
using DAL;
using BLL.DTO.Mappers;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {

            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));
            _unitOfWork = unitOfWork;
        }
        public async Task CreateAsync(UserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
          
            bool isCreated = (await _unitOfWork.Users.FindAsync(x => x.Name == user.Name)).Any();
            if (isCreated)
                throw new ArgumentException("Користувач з даним логіном вже існує");

            _unitOfWork.Users.Create(UserMapper.MapToEntity(user));
           await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            _unitOfWork.Users.Delete(id);
            await _unitOfWork.SaveAsync();
        }

     

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<UserDTO> FindByIdAsync(int id)
        {
           User a= await _unitOfWork.Users.GetAsync(id);
            if (a == null)
                return null;
            return  UserMapper.MapToDTO(a);
        }

     

        public async Task<UserDTO> FindByNameAsync(string name)
        {
            if (name == null)
                throw new ArgumentNullException();
            await _unitOfWork.Users.GetAllAsync();
            var b = (await _unitOfWork.Users.FindAsync(x => x.Name == name)).FirstOrDefault();
           
            if (b == null)
                return null;
            return UserMapper.MapToDTO(b);
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            return (await _unitOfWork.Users.GetAllAsync()).Select(u => UserMapper.MapToDTO(u));
        }
    }
}