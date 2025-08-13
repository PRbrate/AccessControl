# AccessControl

Sistema de controle de acesso desenvolvido em **.NET** utilizando arquitetura limpa.

## Tecnologias
- C# / .NET
- ASP.NET Core
- Entity Framework Core
- PostgreSQL (ou outro banco configurado)
- JWT para autenticação

## Como rodar o projeto

1. **Clonar o repositório**
   ```bash
   git clone https://github.com/PRbrate/AccessControl.git
   cd AccessControl
2. **Restaurar pacotes**
  `dotnet restore`

3. **Configurar o banco de dados**
  - Editar o appsettings.json em ControleDeAcesso.Api com a string de conexão correta.

4. **Rodar migrações**
  `dotnet ef database update --project ControleDeAcesso.Data`

5.**Executar a API**
  `dotnet run --project ControleDeAcesso.Api`

Estrutura

  - ControleDeAcesso.Api → API e endpoints
  - ControleDeAcesso.Application → Casos de uso
  - ControleDeAcesso.Domain → Regras de negócio
  - ControleDeAcesso.Data → Acesso a dados
  - ControleDeAcesso.Core → Contratos e utilitários
