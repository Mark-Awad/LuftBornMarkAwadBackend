using LuftbornBackendCore.Entities;

namespace LuftbornBackendApi.Dtos.Request
{
    public class UserRequestDto
    {
        //public int ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        //public RoleRequestDto Role { get; set; }
    }
}
