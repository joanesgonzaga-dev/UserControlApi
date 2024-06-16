using MailKit.Net.Smtp;
using MimeKit;
using UserControlApi.Model;
using UserControlApi.Model.Enums;

namespace UserControlApi.Service
{
    public class EnviarEmailService
    {
        private IConfiguration _configuration;

        public EnviarEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void EnviarEmail(string[] destinatario, EnumAssuntoEmail ativacaoCadastro, Guid identityUserId, string codigoAtivacao)
        {
            string textoBodyEmail = string.Empty;
            if (ativacaoCadastro == EnumAssuntoEmail.AtivacaoCadastro)
            {
                textoBodyEmail = "Este é um email automático. Não responda a este email.\n" +
                    "Clique no link abaixo para confirmar e ativar a sua conta em nosso sistema.";
            }
            else
            {
                textoBodyEmail = "Este é um email automático. Não responda a este email.\n" +
                    "Clique no link abaixo para confirmar o cancelamento de sua inscrição e sua conta em nosso sistema.";
            }

            Mensagem mensagem = new Mensagem(destinatario, textoBodyEmail, identityUserId, codigoAtivacao);

            MimeMessage email = ConstroiEmail(mensagem);

            Enviar(email);
        }

        private void Enviar(MimeMessage email)
        {
            using (var emailClient = new SmtpClient())
            {

                try
                {
                    emailClient.Connect(_configuration.GetValue<string>("EmailSettings:SmtpServer"),
                        _configuration.GetValue<int>("EmailSettings:Port"), true);
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                    emailClient.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    emailClient.Send(email);
                }
                catch (Exception)
                {

                    throw;
                }

                finally
                {
                    emailClient.Disconnect(true);
                    emailClient.Dispose();
                }
            }
        }

       
        private MimeMessage ConstroiEmail(Mensagem mensagem)
        {
            MimeMessage mensagemDeEmail = new MimeMessage();
            var from = _configuration.GetValue<string>("EmailSettings:From");
            mensagemDeEmail.From.Add(new MailboxAddress(from, from));
            mensagemDeEmail.To.AddRange(mensagem.Destinatario);
            mensagemDeEmail.Subject = mensagem.Assunto;
            mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };

            return mensagemDeEmail;
        }
    }
}
