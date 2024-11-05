99708 - Gabriel Francisco Lobo

552295 - MATHEUS FELIPE CAMARINHA DUARTE

551401 - Ana Luiza Fontes Franco

98672 - Mirelly Ribeiro Azevedo

551856 - Beatriz Fon Ehnert de Santi


# Healy API Web

Bem-vindo ao **Healy API**! Esta é uma aplicação API desenvolvida em C# que realiza operações CRUD para gerenciar recursos relacionados à saúde. O projeto segue uma abordagem monolítica e utiliza padrões de design como o Repository Pattern, o Service Layer e a Dependency Injection para garantir uma arquitetura modular, escalável e fácil de manter.

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
  "Auth0": {
    "Domain": "dev-b42rnz5hakwo5p2s.us.auth0.com",
    "Audience": "healy-auth"
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

### Autenticação JWT Token com Auth0

Para autenticação de usuários, o Healy API Web utiliza JSON Web Tokens (JWT) com o provedor de autenticação externo Auth0. Esta integração com o Auth0 permite uma autenticação segura e gerenciada, mantendo o controle de acesso à API de forma robusta e escalável.

### Testes, Práticas de Clean Code e IA Generativa

# Práticas de Clean Code
Seguindo os princípios de Clean Code, o projeto foi estruturado para:

1. Segregação de Responsabilidades: Divisão clara entre repositórios e serviços, o que facilita a manutenção e o entendimento do código.
2. Nomenclatura Descritiva: Métodos e classes foram nomeados de forma a descrever seu propósito, melhorando a legibilidade.
3. Injeção de Dependências: Uso extensivo de injeção de dependência para reduzir o acoplamento e facilitar a testabilidade.

# Funcionalidades de IA Generativa

A API incorpora Inteligência Artificial Generativa para a recomendação de profissionais da saúde. Utilizando ML.NET, o modelo de recomendação foi treinado com dados históricos e implementado para sugerir profissionais baseados em interações anteriores.
