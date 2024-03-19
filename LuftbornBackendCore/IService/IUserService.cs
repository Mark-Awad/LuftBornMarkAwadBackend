using LuftbornBackendCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornBackendCore.IService
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersByRoleIdAsync(int roleId);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task CreateUserAsync(User newUser);
        Task UpdateUserAsync(User updatedUser);
        Task DeleteUserAsync(int userId);
    }
}
