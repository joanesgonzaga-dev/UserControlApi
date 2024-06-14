using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserControlApi.Model;
using UserControlApi.Model.DTO;

namespace UserControlApi.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<UsuarioCadastroDTO, Usuario>();
            CreateMap<Usuario, IdentityUser<Guid>>();
        }
    }
}
