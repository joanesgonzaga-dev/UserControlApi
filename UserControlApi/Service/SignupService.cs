using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;
using UserControlApi.Model;
using UserControlApi.Model.DTO;

namespace UserControlApi.Service
{
    public class SignupService : ISignupService
    {
        private IMapper _mapper;
        private UserManager<IdentityUser<Guid>> _userManager;
        public SignupService(IMapper mapper, UserManager<IdentityUser<Guid>> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public Result ToRegister(UsuarioCadastroDTO cadastroDTO)
        {
            User usuario = _mapper.Map<User>(cadastroDTO);
            IdentityUser<Guid> identityUser = _mapper.Map<IdentityUser<Guid>>(usuario);
            Task<IdentityResult> result = _userManager.CreateAsync(identityUser, cadastroDTO.Password);

            if (result.Result.Succeeded) {

                var code = _userManager.GenerateEmailConfirmationTokenAsync(identityUser).Result;
                return Result.Ok().WithSuccess(code).WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar usuário");
        }
    }
}

//return Task.CompletedTask; //Esse código apenas pra parar de dar erro