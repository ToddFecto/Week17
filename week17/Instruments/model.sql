create database musicstore;

use musicstore;

create table instrument (
id int NOT NULL AUTO_INCREMENT,
kind varchar(30),
color varchar(20),
PRIMARY KEY(id)
);
