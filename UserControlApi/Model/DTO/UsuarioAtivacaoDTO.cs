using System.ComponentModel.DataAnnotations;

namespace UserControlApi.Model.DTO
{
    public class UsuarioAtivacaoDTO
    {
        [Required]
        public Guid UsuarioId { get; set; }

        [Required]
        public string? CodigoDeAtivacao { get; set; }
    }
}
