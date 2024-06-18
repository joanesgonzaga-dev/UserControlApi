using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using System.Text;

namespace UserControlApi.Model
{
    public class Mensagem
    {
        public Mensagem(IEnumerable<string> destinatario, string assunto, string textoBody, Guid usuarioId, string codigoAtivacao)
        {
            Destinatario = new List<MailboxAddress>();
            Destinatario.AddRange(destinatario.Select(d => new MailboxAddress(d,d)));
            Assunto = assunto;

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(textoBody);
            stringBuilder.Append($"<br /><br />");
            stringBuilder.Append("<a href=");
            stringBuilder.Append($"\"https://localhost:7236/api/account/registrar/ativar?usuarioId={usuarioId}&codigoDeAtivacao={codigoAtivacao}");
            stringBuilder.Append("\"");
            stringBuilder.Append(">");
            stringBuilder.Append("Clique para ativar sua conta");
            stringBuilder.Append("</a>");
          
            stringBuilder.Append("<br /><br /><br />");
            stringBuilder.Append("NOVO LAR EMPREENDIMENTOS");

            Conteudo = stringBuilder.ToString();
        }

        public List<MailboxAddress> Destinatario { get; set; }
        public string Assunto { get; set;}
        public string Conteudo { get; set; }

    }
}
