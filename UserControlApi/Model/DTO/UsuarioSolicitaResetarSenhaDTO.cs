using System.ComponentModel.DataAnnotations;

namespace UserControlApi.Model.DTO
{
    public class UsuarioSolicitaResetarSenhaDTO
    {
        [Required]
        public string Email { get; set; }


    }
}
