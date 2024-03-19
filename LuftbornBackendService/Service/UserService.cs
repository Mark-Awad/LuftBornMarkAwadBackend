using LuftbornBackendCore.Entities;
using LuftbornBackendCore.IRepositry;
using LuftbornBackendCore.IService;
using LuftbornBackendRepository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornBackendService.Service
{
    public class UserService: IUserService
    {
        private readonly IGenericRepository<User, ContextDb> _userRepository;
        public UserService(IGenericRepository<User, ContextDb> userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentException(nameof(userRepository));
        }

        public async Task CreateUserAsync(User newUser)
        {
            await _userRepository.InsertAsync(newUser);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            _userRepository.Delete(userId);
            await _userRepository.SaveAsync();
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            Func<IQueryable<User>, IQueryable<User>> includeProperties = users => users.Include(u => u.Role);
            return await _userRepository.GetAllAsync(includeProperties: includeProperties);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            Expression<Func<User, bool>> filter = user => user.ID == userId;
            Func<IQueryable<User>, IQueryable<User>> includeProperties = users => users.Include(u => u.Role);
            return await _userRepository.FirstOrDefaultAsync(filter, includeProperties);
        }

        public async  Task<IEnumerable<User>> GetUsersByRoleIdAsync(int roleId)
        {
            Expression<Func<User, bool>> filter = user => user.RoleID == roleId;
            Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = users => users.OrderByDescending(u => u.CreatedDate);
            Func<IQueryable<User>, IQueryable<User>> includeProperties = users => users.Include(u => u.Role);
            return await _userRepository.GetAllAsync(filter, orderBy, includeProperties);
        }

        public async Task UpdateUserAsync(User updatedUser)
        {
            _userRepository.Update(updatedUser);
            await _userRepository.SaveAsync();
        }
    }
}
