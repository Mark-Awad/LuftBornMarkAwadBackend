using LuftbornBackendApi.Dtos.Request;

namespace LuftbornBackendApi.Dtos.Response
{
    public class UserResponseDto
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Fullname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public RoleResponseDto Role { get; set; }//might remove or ignore from front end
    }
}
