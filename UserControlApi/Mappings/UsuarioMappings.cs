using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UserControlApi.Model;
using UserControlApi.Model.DTO;

namespace UserControlApi.Mappings
{
    public class UsuarioMappings : Profile
    {
        public UsuarioMappings()
        {
            CreateMap<UsuarioCadastroDTO, Usuario>();
            CreateMap<Usuario, IdentityUser<Guid>>();
        }
    }
}
