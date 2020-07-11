create or REPLACE FUNCTION add_standart_columns (table_name varchar) RETURNS integer AS $$
BEGIN
-- IF table_name IS NULL

-- EXECUTE 
EXECUTE 'alter table '|| table_name ||' add created_on timestamp not null default now();';
EXECUTE 'alter table '|| table_name ||' add created_by int not null;';
EXECUTE 'alter table '|| table_name ||' add updated_on timestamp null;';
EXECUTE 'alter table '|| table_name ||' add updated_by int null;';
EXECUTE 'alter table '|| table_name ||' add is_deleted boolean not null default false;';

EXECUTE 'alter table '|| table_name ||' add constraint fk_'|| table_name ||'_created_by foreign key(created_by) references service_user(id);';
EXECUTE 'alter table '|| table_name ||' add constraint fk_'|| table_name ||'_updated_by foreign key(updated_by) references service_user(id);';
RETURN 1;
END; $$
LANGUAGE PLPGSQL;