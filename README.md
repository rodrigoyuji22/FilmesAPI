# 📘 Projeto: Filmes CRUD API

## 📋 Descrição

Esta é uma API RESTful desenvolvida em C# com ASP.NETCore MVC que implementa operações de **Create**, **Read**, **Update** e **Delete** (CRUD) para gerenciamento de **filmes** com persistência de dados.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core
- C#
- Entity Framework Core
- MySQL
- Swagger

---

## 📦 Pacotes NuGet Utilizados

- AutoMapper.Extensions.Microsoft.DependencyInjection --version 12.0.1
- Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 8.0.5
- Microsoft.EntityFrameworkCore --version 8.0.13
- Microsoft.EntityFrameworkCore.Design --version 8.0.13
- Microsoft.EntityFrameworkCore.Relational --version 8.0.13
- Microsoft.EntityFrameworkCore,Tools --version 8.0.13
- Pomelo.EntityFrameworkCore.MySql --version 8.0.3
- Swashbuckle.AspNetCore --version 6.6.2

## ⚙️ Funcionalidades

- `GET /filme` – Lista todos os registros do banco de dados 
- `GET /filme/{id}` – Retorna um registro específico
- `POST /filme` – Cria um novo registro no banco de dados  
- `PUT /filme/{id}` – Atualiza um registro existente
- `PATCH /filme/{id}` – Atualiza parcialmente um registro
- `DELETE /filme/{id}` – Remove um registro  

---

## 🔧 Como Executar

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download)
- [MySQL](https://dev.mysql.com/downloads/installer/)

### Passos

```bash
# Clone o repositório
git clone https://github.com/rodrigoyuji22/FilmesAPI.git
cd FilmesAPI

# Restaure os pacotes
dotnet restore

# Execute a aplicação
dotnet run
```

## Testes da API

É possível testar os endpoints da API através do Swagger (A API pode ser acessada em [https://localhost:7178/swagger](https://localhost:7178/swagger)

## 📫 Contato

- LinkedIn: [Rodrigo Koike](https://www.linkedin.com/in/rodrigo-koike-83018a2b4/)
- Email: rodrigoyujikoike@gmail.com
