# GymClientControlApi 💻

O GymClientControlApi é um projeto de API desenvolvido para o controle de clientes de uma academia. Com conexão ao banco de dados SQL Server, essa API implementa operações básicas de um CRUD para um gerenciamento eficiente dos clientes. Utilizando protocolos HTTP e JSON, permite a interação com a aplicação de forma simples e sucinta.

## Funcionalidades 🙌

A API oferece os seguintes métodos HTTP:

- `HttpGet` - Metodo em que todos os clientes cadastrados na academia que estão com o status ativo são recuperados e devolvidos em formato de lista. 
- `HttpGet/{document}` - Recupera o cliente correspondente ao documento fornecido como parâmetro.
- `HttpPost` - Verifica se o documento inserido já existe na base de dados. Se não existir, realiza o cadastro do cliente com a matrícula ativada.
- `HttpPut("update/{document}")` - Atualiza os dados do cadastro do cliente, sem permitir reativar a matrícula.
- `HttpPut("activate/{document}")` - Reativa a matrícula do cliente na academia.
- `HttpDelete("{document}")` - Realiza a exclusão lógica do cliente, desativando a matrícula, mas mantendo os dados registrados no banco.

## Tecnologias, Bibliotecas e Padrões 👨‍💻

O projeto utiliza as seguintes tecnologias, bibliotecas e padrões:

- Linguagem: C# 
- Framework: .NET 7.0
- Conceitos: Arquitetura de Camadas e DDD (Domain-Driven Design)
- Práticas: Clean Code
- DTO's: Utilizados para transferência de dados entre as camadas da aplicação
- Testes: XUnit (framework de testes para .NET)
- Banco de Dados: SQL Server (Acessando via Dapper)
- IDE: Visual Studio 2022

## Configuração e Uso 🛠

1. Clone o repositório do projeto.
2. Abra a solução `GymClientControlApi.sln` em sua IDE de preferencia. (Indico Visual Studio 2022)
3. Restaure as dependencias do projeto.
4. Tenha o SQL Server e o SQL Server Management studio Management studio instalado.
5. Realize o download do script de criação do banco de dados que esta presente no repositorio do GitHub com o nome: *Script-Criação-BandoDeDados*.
	5.a Execute o Script de criação em seu SMSS (Sql Server).
6. Compile o projeto.
7. Inicie a aplicação

## Contribuição 🤝

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue para relatar algum problema ou sugerir melhorias.


----------------------------------------------------------------------------------------------------------------------------------------------------------------------


# GymClientControlApi (English) 💻

The GymClientControlApi is an API project developed for client management in a gym. With a connection to a SQL Server database, this API implements basic CRUD operations for efficient client management. It utilizes HTTP and JSON protocols, enabling simple and concise interaction with the application.

## Features 🙌

The API provides the following HTTP methods:

- `HttpGet` - Retrieves all active clients registered in the gym and returns them as a list.
- `HttpGet/{document}` - Retrieves the client corresponding to the provided document as a parameter.
- `HttpPost` - Checks if the inserted document already exists in the database. If it doesn't exist, it registers the client with an active membership.
- `HttpPut("update/{document}")` - Updates the client's registration data, without allowing reactivation of the membership.
- `HttpPut("activate/{document}")` - Activates the client's membership in the gym.
- `HttpDelete("{document}")` - Performs a logical deletion of the client, deactivating the membership while preserving the registered data in the database.

## Technologies, Libraries, and Patterns 👨‍💻

The project utilizes the following technologies, libraries, and patterns:

- Language: C# 
- Framework: .NET 7.0
- Concepts: Layered Architecture and Domain-Driven Design (DDD)
- Best Practices: Clean Code
- DTOs: Used for data transfer between application layers
- Testing: XUnit (testing framework for .NET)
- Database: SQL Server (Accessing via Dapper)
- IDE: Visual Studio 2022

## Setup and Usage 🛠

1. Clone the project repository.
2. Open the GymClientControlApi.sln solution in your preferred IDE (Visual Studio 2022 is recommended).
3. Restore project dependencies.
4. Make sure you have SQL Server and SQL Server Management Studio installed.
5. Download the database creation script from the GitHub repository, named *Script-Criação-BancoDeDados*.
	5.a Execute the creation script in your SQL Server Management Studio (SSMS).
6. Build the project.
7. Start the application.

## Contribution 🤝

Contributions are welcome! Feel free to open an issue to report any problems or suggest improvements.
