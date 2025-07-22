Segunda API – CRUD com .NET 8, Entity Framework Core e MySQL
Este projeto é um CRUD de produtos e categorias, desenvolvido para praticar a criação de APIs RESTful utilizando C# com .NET 8, Entity Framework Core e MySQL. Os endpoints foram testados e visualizados via Swagger.

✨ Tecnologias utilizadas
C#

.NET 8

ASP.NET Core Web API

Entity Framework Core

MySQL

Swagger

💻 Funcionalidades implementadas
✔️ GET – buscar todas as categorias e produtos
✔️ GET by ID – buscar categoria ou produto pelo ID
✔️ POST – cadastrar novas categorias e produtos
✔️ PUT – atualizar dados existentes
✔️ DELETE – excluir categorias ou produtos do banco de dados

📁 Migrations
O projeto utiliza o Code First, ou seja, o banco de dados é criado a partir das classes Models usando migrations do Entity Framework Core.

🚀 Como executar
Clone o repositório:

bash
Copiar
Editar
git clone https://github.com/BrunoAlmeidaRamos/Segunda_API.git
Abra no Visual Studio ou VS Code.

Configure sua string de conexão no appsettings.json:

json
Copiar
Editar
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=SegundaDB;Uid=root;Pwd=;"
}
Execute os seguintes comandos no terminal para criar o banco de dados:

bash
Copiar
Editar
dotnet ef migrations add InitialCreate
dotnet ef database update
Rode o projeto:

bash
Copiar
Editar
dotnet run
Acesse o Swagger em: https://localhost:porta/swagger

📚 Aprendizado
Este projeto faz parte dos meus estudos no curso “O essencial para criar APIs da Web na plataforma .NET” da Udemy. Nele aprendi conceitos fundamentais como:

Criação de endpoints RESTful

Boas práticas com Controllers

Migrations e relacionamentos

Uso do LINQ e AsNoTracking

Testes no Swagger para validação das rotas
