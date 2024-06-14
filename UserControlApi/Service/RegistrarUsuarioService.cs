using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using UserControlApi.Model;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public class RegistrarUsuarioService : IRegistrarUsuarioService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<Guid>> _userManager;
        public RegistrarUsuarioService(IMapper mapper, UserManager<IdentityUser<Guid>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public Result Registrar(UsuarioCadastroDTO cadastroDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(cadastroDTO);
            IdentityUser<Guid> identityUser = _mapper.Map<IdentityUser<Guid>>(usuario);
            Task<IdentityResult> result = _userManager.CreateAsync(identityUser, cadastroDTO.Password);

            if (result.Result.Succeeded) {

                var code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }

        public Result Ativar(UsuarioAtivacaoDTO usuarioDTO)
        {
            IdentityUser<Guid>? identityUser = _userManager.Users.FirstOrDefault(
                u => u.Id == usuarioDTO.UsuarioId);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, usuarioDTO.CodigoDeAtivacao).Result;

            if (identityResult.Succeeded)
            {
                return Result.Ok();
            }

            return Result.Fail("Ocorreu um erro ao ativar a conta");
        }
    }
}

//return Task.CompletedTask; //Esse código apenas pra parar de dar erro