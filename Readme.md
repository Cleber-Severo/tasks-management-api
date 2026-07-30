# ✅ Tasks Management API

Uma API REST simples desenvolvida em **ASP.NET Core** para gerenciamento de tarefas. O projeto foi criado com fins de estudo, aplicando conceitos como arquitetura em camadas, Use Cases, Repository Pattern, Injeção de Dependência, FluentValidation e tratamento de exceções.

## Funcionalidades

- Criar uma tarefa
- Listar todas as tarefas
- Buscar uma tarefa por ID
- Atualizar uma tarefa
- Remover uma tarefa

> Atualmente os dados são armazenados em memória, ou seja, são perdidos ao encerrar a aplicação.

---

## Tecnologias

- .NET 8
- ASP.NET Core Web API
- Swagger / OpenAPI
- FluentValidation
- Injeção de Dependência (Dependency Injection)

---

## Arquitetura

O projeto foi organizado em camadas para separar responsabilidades e facilitar a manutenção.

- **API**: Controllers e configuração da aplicação.
- **Application**: Casos de uso (Use Cases) e regras de negócio.
- **Communication**: Requests, Responses, Entidades e Enums compartilhados.
- **Infrastructure**: Implementação do repositório em memória.

---

## Rotas

| Método | Endpoint | Descrição |
|---------|----------|-----------|
| GET | `/api/tasks` | Lista todas as tarefas |
| GET | `/api/tasks/{id}` | Busca uma tarefa pelo ID |
| POST | `/api/tasks` | Cria uma nova tarefa |
| PUT | `/api/tasks/{id}` | Atualiza uma tarefa existente |
| DELETE | `/api/tasks/{id}` | Remove uma tarefa |

---

## Como executar o projeto

### 1. Clone o repositório

```bash
git clone https://github.com/Cleber-Severo/tasks-management-api.git
```

Entre na pasta do projeto:

```bash
cd TasksManagementApi
```

---

### 2. Restaurar os pacotes NuGet

```bash
dotnet restore
```

Ou utilize a opção **Restore NuGet Packages** pelo Visual Studio.

---

### 3. Executar a aplicação

```bash
dotnet run
```

Caso utilize o Visual Studio, basta definir o projeto **TasksManagementApi.API** como **Startup Project** e pressionar **F5** ou **Ctrl + F5**.

---

## Swagger

Após iniciar a aplicação, acesse:

```
https://localhost:7003/swagger
```

> A porta pode variar conforme a configuração do projeto.

O Swagger permite visualizar e testar todos os endpoints da API.

---

## Estrutura do projeto

```text
TasksManagementApi
│
├── TasksManagementApi.API
│   ├── Controllers
│   └── Program.cs
│
├── TasksManagementApi.Application
│   └── UseCases
│
├── TasksManagementApi.Communication
│   ├── Entities
│   ├── Enums
│   ├── Requests
│   └── Responses
│
└── TasksManagementApi.Infrastructure
    └── Repositories
        ├── Interfaces
        └── InMemory
```

---

## Modelo da tarefa

Cada tarefa possui as seguintes informações:

- **Id**
- **Nome**
- **Descrição**
- **Prioridade**
- **Data de vencimento**
- **Status**

As validações incluem:

- O nome é obrigatório.
- O nome deve possuir no máximo **100 caracteres**.
- A data de vencimento não pode estar no passado.

---

## Observações

- Os dados são armazenados apenas em memória.
- Não há persistência em banco de dados.
- O projeto foi desenvolvido com foco em aprendizado de arquitetura em camadas, Use Cases, Repository Pattern e boas práticas de desenvolvimento com ASP.NET Core.