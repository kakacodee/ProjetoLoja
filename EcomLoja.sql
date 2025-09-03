drop database EcomLoja;
create database EcomLoja;
use EcomLoja;

create table produto(
Id int primary key auto_increment,
Nome varchar(50),
Descricao varchar(100),
Preco decimal(10,2),
ImageUrl varchar(255),
Estoque int
);

create table pedido(
Id int primary key auto_increment ,
DataPedido datetime,
Total decimal(10,2),
Status varchar(50),
Endereco varchar(100),
FormaPagamento varchar(100),
Frete decimal (10,2)
);


create table itemPedido(
Id int primary key auto_increment ,
PedidoId int,
ProdutoId int,
Quantidade int,
PrecoUnitario decimal(10,2)
);

-- CONSULTANDO AS TABELAS DO BANCO

select * from produto;
select * from pedido;
select * from itemPedido;
insert into produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('John Pork','John Pork',150.00, 'imagens/jogo1.jfif',10);
insert into produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Steak','Steak',150.00, 'imagens/jogo2.jpeg',10);
insert into produto(Nome,Descricao,Preco,ImageUrl,Estoque)values('Galinha da Nike','Galinha da Nike',150.00, 'imagens/galinha da Nike.jfif',10);