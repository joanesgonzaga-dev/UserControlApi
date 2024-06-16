# Web API de Autenticação e Autorização
Esta API é um serviço de backend desenvolvido em .NET 6, utilizando o ASP.NET Core Identity para autenticação e autorização de usuários. Os dados são armazenados em um banco de dados MySQL. A API não possui frontend ou views, sendo focada exclusivamente em fornecer serviços de autenticação e autorização.

## Motivação
Fornecer segurança de acesso à aplicação de gestão de contratos imobiliários

## Requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- Ferramenta para testes de API (Postman, Curl, etc.)

## Instalação

1. **Clone o repositório**

   ```bash
   git clone https://github.com/joanesgonzaga-dev/UserControlApi.git
   ```
   ````bash
   cd https://github.com/joanesgonzaga-dev/UserControlApi.git
   ````
## Endpoints
1. **Registro de Usuário**
   * Método HTTP: POST
   * URL: `api/account/registrar`
   * Parâmetros (Body):
        * userName (string): Nome de usuário
        * email (string): Email de Usuário
        * password (string): Senha de Usuário
        * passwordConfirmed (string): Confirmação de Senha de Usuário
   * Resposta:
        * 200 OK: Usuário registrado com sucesso
        * 400 Bad Request: Erro de validação
          
2. **Ativação de Conta de Usuário**
   * Método HTTP: GET
   * URL: `api/account/ativar?usuarioId={usuarioId}&codigoDeAtivacao={codigoDeAtivacao}`
   * Parâmetros (QueryParams):
        * usuarioId (string): Código (Guid) de identificação de usuário no sistema
        * codigoDeAtivacao (string): Tooken recebido pela aplicação para validar ativação de conta de usuário
   * Resposta:
     * 200 OK: Usuário logado com sucesso
     * 500 Bad Request: Erro interno

3. **Login de Usuário**
   * Método HTTP: POST
   * URL: `api/account/login`
   * Parâmetros:
        continua...
   * Resposta:
     * 200 OK: Usuário logado com sucesso
     * 400 Bad Request: Erro de credenciais

   [Link para documentação](https://adefinir.com)
   
## Considerações Finais
Esta API foi desenvolvida para fornecer um serviço robusto de autenticação e autorização utilizando as melhores práticas do ASP.NET Core Identity e JWT. Certifique-se de proteger adequadamente suas chaves e tokens e de seguir boas práticas de segurança para evitar vulnerabilidades.  

### Api Desenvolvida por:
Joanes Gonzaga
