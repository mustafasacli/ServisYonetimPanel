create table service_detail
(
id serial not null,
service_id int not null references service(id),
detail_type_id int not null references service_detail_type(id),
info varchar(500) null,
constraint pk_service_detail primary key(id)
);

select add_standart_columns('service_detail');