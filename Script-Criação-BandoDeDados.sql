-- Cria o banco de dados
CREATE DATABASE GymControlClients;
GO

-- Usa o banco de dados recém-criado
USE GymControlClients;
GO

-- Cria a tabela Clients
CREATE TABLE Clients (
    Document NVARCHAR(20) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    DateBirth DATE NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    ActiveSubscription BIT,
    ContractTime INT NOT NULL,
    RegistrationDate DATETIME
);
