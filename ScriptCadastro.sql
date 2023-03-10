CREATE DATABASE bancoecommerce;

USE bancoecommerce


-- Criação da tabelas de cadastro

CREATE TABLE usuario (id INTEGER IDENTITY(1,1) PRIMARY KEY, nome varchar(200), telefone varchar(12), senha text, endereco_id integer FOREIGN KEY REFERENCES endereco(end_id))

CREATE TABLE endereco (end_id INTEGER IDENTITY(1,1) PRIMARY KEY, rua varchar(250), numero varchar(10), complemento varchar(100),cidade varchar(200), estado varchar(100), cep varchar(8))

INSERT INTO usuario(nome,telefone,senha) VALUES('Joyce','81988010366','1234');
INSERT INTO endereco(rua, numero,complemento, cidade,estado,cep) VALUES ('Rua Abatia','218','Casa 02','Recife','Pernambuco','50440330')
SELECT * FROM usuario
SELECT * FROM endereco




--Inserir um usuario
INSERT INTO 
usuario(nome,telefone,senha,endereco_id) 
VALUES('Joyce','81988010366','1234',1);

-- Select para carregar objeto do tipo User
SELECT nome,telefone,senha,rua,numero,complemento, cidade,estado,cep
FROM endereco 
INNER JOIN usuario ON endereco.end_id=usuario.endereco_id

-- Deletar um usuario consequentemente seu endereço atribuido
DELETE FROM usuario WHERE id=1





------------------------------------------------------------------------------------------

-- Produtos - Criar tabela objeto produtos de acordo com as informações necessárias do Mercado Pago 
CREATE TABLE produto (end_id INTEGER IDENTITY(1,1) PRIMARY KEY, )