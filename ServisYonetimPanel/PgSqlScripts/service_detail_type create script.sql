drop table service_detail_type;

create table service_detail_type
(
id serial not null,
detail_type_name varchar(100) not null,
constraint pk_service_detail_type primary key(id)
);

select add_standart_columns('service_detail_type');