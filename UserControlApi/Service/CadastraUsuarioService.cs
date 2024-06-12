using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using UserControlApi.Model;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public class CadastraUsuarioService : ICadastraUsuarioService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<Guid>> _userManager;
        public CadastraUsuarioService(IMapper mapper, UserManager<IdentityUser<Guid>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public Result CadastraUsuario(UsuarioCadastroDTO cadastroDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(cadastroDTO);
            IdentityUser<Guid> identityUser = _mapper.Map<IdentityUser<Guid>>(usuario);
            Task<IdentityResult> result = _userManager.CreateAsync(identityUser, cadastroDTO.Password);

            if (result.Result.Succeeded) return Result.Ok();
            return Result.Fail("Falha ao cadastrar usuário");
        }
    }
}

//return Task.CompletedTask; //Esse código apenas pra parar de dar erro