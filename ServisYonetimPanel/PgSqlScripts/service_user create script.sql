drop table service_user;

create table service_user(
id serial not null,
user_name varchar(100) not null,
first_name varchar(100) not null,
last_name varchar(100) not null,
email varchar(250) not null,
password varchar(250) not null,
constraint pk_service_user primary key(id) 
);
select add_standart_columns('service_user');