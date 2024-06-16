using MimeKit;

namespace UserControlApi.Model
{
    public class Mensagem
    {
        public Mensagem(IEnumerable<string> destinatario, string assunto, Guid usuarioId, string codigoAtivacao)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d,d)));
            Assunto = assunto;
            Conteudo = $"http://localhost:5241/api/account/registrar/ativar?usuarioId={usuarioId}&codigoAtivacao={codigoAtivacao}";
        }

        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set;}
        public string Conteudo { get; set; }

    }
}
