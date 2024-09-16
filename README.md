99708 - Gabriel Francisco Lobo

552295 - MATHEUS FELIPE CAMARINHA DUARTE

551401 - Ana Luiza Fontes Franco

98672 - Mirelly Ribeiro Azevedo

551856 - Beatriz Fon Ehnert de Santi


# Healy API Web

Bem-vindo ao **Healy API Web**! Esta é uma aplicação de API desenvolvida em C# que realiza operações CRUD para gerenciar recursos relacionados à saúde. O projeto segue uma abordagem monolítica e utiliza padrões de design como o Repository Pattern, o Service Layer e a Dependency Injection para garantir uma arquitetura modular, escalável e fácil de manter.

## Abordagem Monolítica

Optamos por uma arquitetura monolítica para este projeto pelas seguintes razões:

### Simplicidade e Facilidade de Desenvolvimento

Uma arquitetura monolítica simplifica o desenvolvimento inicial ao manter todos os componentes e funcionalidades dentro de um único projeto. Isso facilita a configuração, o desenvolvimento e a implantação da aplicação.

### Manutenção Centralizada

Manter uma aplicação monolítica pode ser mais direto do que gerenciar vários serviços distribuídos. Com uma única base de código, é mais fácil realizar atualizações, corrigir bugs e garantir a integridade dos dados.

## Configuração do Projeto

Para configurar e executar o projeto, siga as instruções abaixo:

### 1. Clonar o Repositório

```bash
git clone https://github.com/gabrielLoboo/Healy-API-Web.git
```

### 2. Configurar Variaveis de Ambiente

Configure as variáveis de ambiente necessárias, como a string de conexão com o banco de dados, no arquivo appsettings.json ou através das variáveis de ambiente do sistema.

```bash
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=mydatabase;User Id=myuser;Password=mypassword;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning"
    }
  }
}
```

### 3. Executar aplicação

```bash
dotnet run
```
