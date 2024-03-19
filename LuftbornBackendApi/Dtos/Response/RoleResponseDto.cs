using LuftbornBackendApi.Dtos.Request;

namespace LuftbornBackendApi.Dtos.Response
{
    public class RoleResponseDto
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        //public  ICollection<UserResponseDto> Users { get; set; }
    }
}
