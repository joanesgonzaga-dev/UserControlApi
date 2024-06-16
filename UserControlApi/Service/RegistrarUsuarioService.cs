using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using System.Web;
using UserControlApi.Model;
using UserControlApi.Model.DTO;
using UserControlApi.Model.Enums;

namespace UserControlApi.Service
{
    public class RegistrarUsuarioService : IRegistrarUsuarioService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<Guid>> _userManager;
        private EnviarEmailService _enviarEmailService;
        public RegistrarUsuarioService(IMapper mapper, UserManager<IdentityUser<Guid>> userManager, EnviarEmailService enviarEmailService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _enviarEmailService = enviarEmailService;
        }
        public Result Registrar(UsuarioCadastroDTO cadastroDTO)
        {
                Usuario usuario = _mapper.Map<Usuario>(cadastroDTO);
                IdentityUser<Guid> identityUser = _mapper.Map<IdentityUser<Guid>>(usuario);
                Task<IdentityResult> result = _userManager.CreateAsync(identityUser, cadastroDTO.Password);

                //Gera Token de Confirmação
                if (result.Result.Succeeded)
                {
                    var codigoAtivacao = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
                    //Encoded para email
                    var encodedToken = HttpUtility.UrlEncode(codigoAtivacao);

                    //Envia email de confirmação
                    _enviarEmailService.EnviarEmail(new[] { identityUser.Email }, EnumAssuntoEmail.AtivacaoCadastro, identityUser.Id, encodedToken);

                    return Result.Ok().WithSuccess(codigoAtivacao);
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