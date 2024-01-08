create database dbhospedaria;
use dbhospedaria;

create table tb_cliente(
	id_cliente int primary key auto_increment,
    nm_cliente varchar(100) not null,
    ds_cpf varchar(15) not null,
    nr_celular varchar(15) not null,
    ds_email varchar(100),
    dt_nascimento date not null,
    ds_nacionalidade varchar(100) not null
);

create table tb_hospedagem(
	id_hospedagem int primary key auto_increment,
    ds_tipo_hospedagem varchar(100) not null,
    vl_diaria decimal(15,2) not null,
    vl_multa_hora decimal(15,2) not null
);

create table tb_quarto(
	id_quarto int primary key auto_increment,
    nr_quarto varchar(30) not null,
    bl_disponivel bool not null,
    bl_varanda bool not null,
    bl_suite bool not null,
    bl_cafe_manha bool not null,
    ds_quarto varchar(100) not null,
    id_hospedagem int not null,
    
    foreign key(id_hospedagem) references tb_hospedagem (id_hospedagem)
);

create table tb_cliente_hospedagem(
	id_cliente_hospedagem int primary key auto_increment,
    dt_estadia datetime not null,
    qtd_dias int not null, 
    id_cliente int not null,
    id_quarto int not null,

	foreign key(id_cliente) references tb_cliente (id_cliente),
	foreign key(id_quarto) references tb_quarto (id_quarto)   
);

create table tb_checkin(
	id_checkin int primary key auto_increment,
    nm_cliente varchar(100) not null,
    ds_cpf varchar(15) not null,
    nr_quarto varchar(30) not null,
    dt_hora_checkin datetime not null,
    id_cliente int not null,
    id_quarto int not null,
    
    foreign key(id_cliente) references tb_cliente(id_cliente),
	foreign key(id_quarto) references tb_quarto (id_quarto)   
);

create table tb_checkout(
	id_checkout int primary key auto_increment, 
    nm_cliente varchar(100) not null,
    nr_quarto varchar(30) not null,
    dt_hora_checkout datetime not null,
    id_checkin int not null,
    
	foreign key(id_checkin) references tb_checkin (id_checkin)   
);

