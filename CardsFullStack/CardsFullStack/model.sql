create database CardGame;

use CardGame;

create table Deck (
	deck_id varchar(20),
    username varchar(20),
	created_at datetime,
    PRIMARY KEY(deck_id)
);

create table Card (
	id int NOT NULL AUTO_INCREMENT,
    deck_id varchar(20),
    image varchar(200),
    cardcode char(2),
    username varchar(20),
    created_at datetime,
    PRIMARY KEY(id)
);
