using System.ComponentModel.DataAnnotations;

namespace UserControlApi.Model.DTO
{
    public class UsuarioLoginDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
