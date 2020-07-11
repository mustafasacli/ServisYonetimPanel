-- DROP TABLE syp.service

CREATE TABLE syp.service (
	id serial NOT NULL,
	name varchar(50) NOT NULL,
	CONSTRAINT pk_service PRIMARY KEY (id)
);
select add_standart_columns('service');