# AuthService - Template de Microsserviço (.NET 9)

Este é um template profissional de autenticação (Backend) desenvolvido com as melhores práticas de mercado: Clean Architecture, Docker e .NET 9.

Pronto para ser integrado em novos projetos ou usado como base de estudos.

## 🚀 Tecnologias Utilizadas

* **.NET 9** (ASP.NET Core Web API)
* **Clean Architecture** (Separação em Domain, Application, Infra, Api)
* **Docker & Docker Compose** (Ambiente isolado e pronto para rodar)
* **PostgreSQL** (Banco de dados)
* **Entity Framework Core** (ORM)
* **ASP.NET Core Identity** (Gestão de usuários segura)
* **JWT (JSON Web Token)** (Autenticação Bearer)
* **MediatR** (Padrão CQRS e desacoplamento)
* **Swagger** (Documentação interativa da API)

## ⚙️ Como Rodar (Passo a Passo)

### Pré-requisitos
* Docker Desktop instalado.

### 1. Subir o Ambiente
Abra o terminal na pasta raiz do projeto e execute:

docker compose up -d --build
Isso irá baixar o banco de dados, configurar a rede e subir a API na porta 5000

### 2. Criar o Banco de Dados
Na primeira vez, é necessário criar as tabelas. No terminal, execute:

dotnet ef database update -p src/AuthService.Infrastructure -s src/AuthService.Api

### 3. Acessar
Abra seu navegador em: http://localhost:5000/swagger

🧪 Como Testar (Fluxo Básico)
Criar Conta: Use o endpoint POST /api/Auth/register para criar um usuário.

Login: Use o endpoint POST /api/Auth/login com os dados criados.

Pegar Token: Copie o accessToken gerado.

Autenticar: Clique no botão Authorize (cadeado) no topo do Swagger, digite Bearer SEU_TOKEN e confirme.

Testar: Tente acessar o endpoint GET /api/Auth/me para ver seus dados protegidos.