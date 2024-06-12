using System.ComponentModel.DataAnnotations;

namespace UserControlApi.Model.DTO
{
    public class UsuarioCadastroDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }
    }
}
