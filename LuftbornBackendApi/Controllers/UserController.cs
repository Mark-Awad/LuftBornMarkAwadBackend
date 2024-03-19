using AutoMapper;
using LuftbornBackendApi.Dtos.Request;
using LuftbornBackendApi.Dtos.Response;
using LuftbornBackendCore.Entities;
using LuftbornBackendCore.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LuftbornBackendApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        
        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserRequestDto>> CreateUser([FromBody] UserRequestDto newUser)
        {
            if (newUser == null){return BadRequest("User data is invalid");}
            User user = _mapper.Map<User>(newUser);
            await _userService.CreateUserAsync(user);
            UserResponseDto createdUser = _mapper.Map<UserResponseDto>(user);

            return Ok(_mapper.Map<UserResponseDto>(createdUser));
            //return CreatedAtAction(nameof(GetUserByIdAsync), new { id = createdUser.ID }, createdUser);
        }


        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(_mapper.Map<List<UserResponseDto>>(users));
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<UserResponseDto>> GetUserByIdAsync(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null){return NotFound();}
            return Ok(_mapper.Map<UserResponseDto>(user));
        }
        [HttpGet("GetUsersByRoleId")]
        public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsersByRoleIdAsync(int roleId)
        {
            var users = await _userService.GetUsersByRoleIdAsync(roleId);
            if (users == null) { return NotFound(); }
            return Ok(_mapper.Map<List<UserResponseDto>>(users));
        }
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<UserRequestDto>> UpdateUserAsync(int id, [FromBody] UserRequestDto updatedUser)
        {
            if (updatedUser == null ){return BadRequest("User data is invalid");}
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null){return NotFound();}
            _mapper.Map(updatedUser, existingUser);
            await _userService.UpdateUserAsync(existingUser);
            return Ok(_mapper.Map<UserResponseDto>(updatedUser));
        }
        [HttpDelete("DeleteUser/{id}")]
        public async Task<ActionResult> DeleteUserAsync(int id)
        {
            var userToDelete = await _userService.GetUserByIdAsync(id);
            if (userToDelete == null){return NotFound();}
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
