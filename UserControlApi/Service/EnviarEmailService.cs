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
            string assuntoEmail = string.Empty;
            string corpoEmail = string.Empty;
            if (ativacaoCadastro == EnumAssuntoEmail.AtivacaoCadastro)
            {
                assuntoEmail = "Novo Lar - Ative a sua conta";
                corpoEmail = "Este é um e-mail automático. Não responda a este email.\n" +
                    "Clique no link abaixo para ativar sua conta conosco e utilizar nossas vantagens.\n";
            }
            else
            {
                assuntoEmail = "Novo Lar - Exclusão sua conta";
            }

            Mensagem mensagem = new Mensagem(destinatario, assuntoEmail, corpoEmail,identityUserId, codigoAtivacao);
            
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
                        _configuration.GetValue<int>("EmailSettings:Port"), MailKit.Security.SecureSocketOptions.StartTls);
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                    emailClient.Authenticate(_configuration.GetValue<string>("EmailSettings:From"),
                        _configuration.GetValue<string>("EmailSettings:Password"));
                    emailClient.SslProtocols = System.Security.Authentication.SslProtocols.Tls;
                    
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
