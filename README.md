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

- Linguagem: C# 7.0
- Framework: .NET
- Conceitos: Arquitetura de Camadas e DDD (Domain-Driven Design)
- Práticas: Clean Code
- DTO's: Utilizados para transferência de dados entre as camadas da aplicação
- Testes: XUnit (framework de testes para .NET)
- Banco de Dados: SQL Server 
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

