
insert into tb_cliente(nm_cliente, ds_cpf, nr_celular, ds_email, dt_nascimento, ds_nacionalidade)
values('Bruno Gomes', '123.123.123-22', '11 9909-0011', 'brunoG@gmail.com', '2002-01-01', 'brasileiro');

insert into tb_cliente(nm_cliente, ds_cpf, nr_celular, ds_email, dt_nascimento, ds_nacionalidade)
values('Gabriel Amorim', '321.123.123-13', '11 9910-2211', 'GabrielAm@gmail.com', '2004-11-01', 'brasileiro');

insert into tb_hospedagem(ds_tipo_hospedagem, vl_diaria, vl_multa_hora)
values('quarto básico', 110.90, 12.99);

insert into tb_hospedagem(ds_tipo_hospedagem, vl_diaria, vl_multa_hora)
values('quarto padrão', 249.99, 49.99);

insert into tb_hospedagem(ds_tipo_hospedagem, vl_diaria, vl_multa_hora)
values('quarto de luxo', 399.99, 69.99);

insert into tb_quarto(nr_quarto, bl_disponivel, bl_varanda, bl_suite, bl_cafe_manha, ds_quarto, id_hospedagem)
values('Q23', true, false, false, true, 'um quarto e banheiro', 1);

insert into tb_quarto(nr_quarto, bl_disponivel, bl_varanda, bl_suite, bl_cafe_manha, ds_quarto, id_hospedagem)
values('Q28', true, false, false, true, 'um quarto e banheiro', 1);

insert into tb_quarto(nr_quarto, bl_disponivel, bl_varanda, bl_suite, bl_cafe_manha, ds_quarto, id_hospedagem)
values('B33', true, true, false, true, 'dois quartos e um banheiro', 2);

insert into tb_quarto(nr_quarto, bl_disponivel, bl_varanda, bl_suite, bl_cafe_manha, ds_quarto, id_hospedagem)
values('B41', true, true, false, true, 'dois quartos e um banheiro', 2);

insert into tb_quarto(nr_quarto, bl_disponivel, bl_varanda, bl_suite, bl_cafe_manha, ds_quarto, id_hospedagem)
values('A14', true, true, true, true, 'dois quartos, um banheiro e uma suite', 3);

insert into tb_quarto(nr_quarto, bl_disponivel, bl_varanda, bl_suite, bl_cafe_manha, ds_quarto, id_hospedagem)
values('A03', true, true, true, true, 'dois quartos, um banheiro e uma suite', 3);

insert into tb_cliente_hospedagem(dt_estadia, qtd_dias, id_cliente, id_quarto)
values('2024-01-01', 6, 1, 5);

insert into tb_cliente_hospedagem(dt_estadia, qtd_dias, id_cliente, id_quarto)
values('2023-12-22', 10, 2, 3);

insert into tb_cliente_hospedagem(dt_estadia, qtd_dias, id_cliente, id_quarto)
values('2023-12-05', 4, 1, 3);

insert into tb_checkin(nm_cliente, ds_cpf, nr_quarto, dt_hora_checkin, id_cliente, id_quarto)
values('Bruno Gomes', '123.123.123-22', 'B33', '2023-12-05 10-30-00', 1, 3);

insert into tb_checkin(nm_cliente, ds_cpf, nr_quarto, dt_hora_checkin, id_cliente, id_quarto)
values('Gabriel Amorim', '321.123.123-13', 'B33', '2023-12-22 08-30-40', 2, 3);

insert into tb_checkin(nm_cliente, ds_cpf, nr_quarto, dt_hora_checkin, id_cliente, id_quarto)
values('Bruno Gomes', '123.123.123-22', 'A14', '2024-01-01 07-49-00', 1, 5);

insert into tb_checkout(nm_cliente, nr_quarto, dt_hora_checkout, id_checkin)
values('Bruno Gomes', 'B33', '2024-01-07 11-25-00', 1);

insert into tb_checkout(nm_cliente, nr_quarto, dt_hora_checkout, id_checkin)
values('Gabriel Amorim', 'B33', '2024-01-01 10-27-10', 2);

insert into tb_checkout(nm_cliente, nr_quarto, dt_hora_checkout, id_checkin)
values('Bruno Gomes', 'A14', '2023-12-09 11-25-00', 3);

select * from tb_cliente;
select * from tb_hospedagem;
select * from tb_quarto;
select * from tb_cliente_hospedagem;
select * from tb_checkin;
select * from tb_checkout;