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
   * URL: `/registrar`
   * Parâmetros (Body):
        * userName (string): Nome de usuário
        * email (string): Email de Usuário
        * password (string): Senha de Usuário
        * passwordConfirmed (string): Confirmação de Senha de Usuário
   * Resposta:
        * 200 OK: Usuário registrado com sucesso
        * 400 Bad Request: Falha ao cadastrar usuário
          
2. **Ativação de Conta de Usuário**
   * Método HTTP: GET
   * URL: `/ativar?usuarioId={usuarioId}&codigoDeAtivacao={codigoDeAtivacao}`
   * Parâmetros (QueryParams):
        * usuarioId (string): Código (Guid) de identificação de usuário no sistema
        * codigoDeAtivacao (string): Tooken recebido pela aplicação para validar ativação de conta de usuário
   * Resposta:
     * 200 OK: Usuário logado com sucesso
     * 500 Internal Server Error: Ocorreu um erro ao ativar a conta

3. **Login de Usuário**
   * Método HTTP: POST
   * URL: `/login`
   * Parâmetros:
       * userName (string): Código (Guid) de identificação de usuário no sistema
       * Password (string): Senha de usuário
   * Resposta:
     * 200 OK: Usuário logado com sucesso
     * 401 Unauthorized: Não foi possível executar o login

4. **Logout de Usuário**
   * Método HTTP: POST
   * URL: `/logout`
   * Parâmetros:
      * Nenhum
   * Resposta:
     * 200 OK
     * 500 Internal Server Error: Erro ao tentar executar Logout

5. **Solicitar Alteração de Senha**
   * Método HTTP: POST
   * URL: `/solicitar-reset`
   * Parâmetros:
       * email (string): Email de identificação de usuário no sistema
   * Resposta:
     * 200 OK
     * 401 Unauthorized: Falha ao solicitar alteração de senha


   [Link para documentação](https://adefinir.com)
   
## Considerações Finais
Esta API foi desenvolvida para fornecer um serviço robusto de autenticação e autorização utilizando as melhores práticas do ASP.NET Core Identity e JWT. Certifique-se de proteger adequadamente suas chaves e tokens e de seguir boas práticas de segurança para evitar vulnerabilidades.  

### Api Desenvolvida por:
Joanes Gonzaga
