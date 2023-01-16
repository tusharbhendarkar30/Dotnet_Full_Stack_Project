DROP DATABASE IF EXISTS product;
create database product;
use product;
create table products(userid integer primary key auto_increment, username varchar(50), course varchar(50), purchasedate date);

insert into products values(1, "AlooBhujiya", "6", "700");
insert into products(productname ,productqty ,price)values("Dairymilk","50", "400");