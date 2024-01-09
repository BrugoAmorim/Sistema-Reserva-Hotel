using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public partial class DbhospedariaContext : DbContext
{
    public DbhospedariaContext()
    {
    }

    public DbhospedariaContext(DbContextOptions<DbhospedariaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCheckin> TbCheckins { get; set; }

    public virtual DbSet<TbCheckout> TbCheckouts { get; set; }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbClienteHospedagem> TbClienteHospedagems { get; set; }

    public virtual DbSet<TbHospedagem> TbHospedagems { get; set; }

    public virtual DbSet<TbQuarto> TbQuartos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("host=localhost;user=root;password=12345;database=dbhospedaria", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TbCheckin>(entity =>
        {
            entity.HasKey(e => e.IdCheckin).HasName("PRIMARY");

            entity.ToTable("tb_checkin");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.HasIndex(e => e.IdQuarto, "id_quarto");

            entity.Property(e => e.IdCheckin).HasColumnName("id_checkin");
            entity.Property(e => e.DsCpf)
                .HasMaxLength(15)
                .HasColumnName("ds_cpf");
            entity.Property(e => e.DtHoraCheckin)
                .HasColumnType("datetime")
                .HasColumnName("dt_hora_checkin");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdQuarto).HasColumnName("id_quarto");
            entity.Property(e => e.NmCliente)
                .HasMaxLength(100)
                .HasColumnName("nm_cliente");
            entity.Property(e => e.NrQuarto)
                .HasMaxLength(30)
                .HasColumnName("nr_quarto");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbCheckins)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_checkin_ibfk_1");

            entity.HasOne(d => d.IdQuartoNavigation).WithMany(p => p.TbCheckins)
                .HasForeignKey(d => d.IdQuarto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_checkin_ibfk_2");
        });

        modelBuilder.Entity<TbCheckout>(entity =>
        {
            entity.HasKey(e => e.IdCheckout).HasName("PRIMARY");

            entity.ToTable("tb_checkout");

            entity.HasIndex(e => e.IdCheckin, "id_checkin");

            entity.Property(e => e.IdCheckout).HasColumnName("id_checkout");
            entity.Property(e => e.DtHoraCheckout)
                .HasColumnType("datetime")
                .HasColumnName("dt_hora_checkout");
            entity.Property(e => e.IdCheckin).HasColumnName("id_checkin");
            entity.Property(e => e.NmCliente)
                .HasMaxLength(100)
                .HasColumnName("nm_cliente");
            entity.Property(e => e.NrQuarto)
                .HasMaxLength(30)
                .HasColumnName("nr_quarto");

            entity.HasOne(d => d.IdCheckinNavigation).WithMany(p => p.TbCheckouts)
                .HasForeignKey(d => d.IdCheckin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_checkout_ibfk_1");
        });

        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("tb_cliente");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.DsCpf)
                .HasMaxLength(15)
                .HasColumnName("ds_cpf");
            entity.Property(e => e.DsEmail)
                .HasMaxLength(100)
                .HasColumnName("ds_email");
            entity.Property(e => e.DsNacionalidade)
                .HasMaxLength(100)
                .HasColumnName("ds_nacionalidade");
            entity.Property(e => e.DtNascimento).HasColumnName("dt_nascimento");
            entity.Property(e => e.NmCliente)
                .HasMaxLength(100)
                .HasColumnName("nm_cliente");
            entity.Property(e => e.NrCelular)
                .HasMaxLength(15)
                .HasColumnName("nr_celular");
        });

        modelBuilder.Entity<TbClienteHospedagem>(entity =>
        {
            entity.HasKey(e => e.IdClienteHospedagem).HasName("PRIMARY");

            entity.ToTable("tb_cliente_hospedagem");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.HasIndex(e => e.IdQuarto, "id_quarto");

            entity.Property(e => e.IdClienteHospedagem).HasColumnName("id_cliente_hospedagem");
            entity.Property(e => e.DtEstadia)
                .HasColumnType("datetime")
                .HasColumnName("dt_estadia");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.IdQuarto).HasColumnName("id_quarto");
            entity.Property(e => e.QtdDias).HasColumnName("qtd_dias");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbClienteHospedagems)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_cliente_hospedagem_ibfk_1");

            entity.HasOne(d => d.IdQuartoNavigation).WithMany(p => p.TbClienteHospedagems)
                .HasForeignKey(d => d.IdQuarto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_cliente_hospedagem_ibfk_2");
        });

        modelBuilder.Entity<TbHospedagem>(entity =>
        {
            entity.HasKey(e => e.IdHospedagem).HasName("PRIMARY");

            entity.ToTable("tb_hospedagem");

            entity.Property(e => e.IdHospedagem).HasColumnName("id_hospedagem");
            entity.Property(e => e.DsTipoHospedagem)
                .HasMaxLength(100)
                .HasColumnName("ds_tipo_hospedagem");
            entity.Property(e => e.VlDiaria)
                .HasPrecision(15, 2)
                .HasColumnName("vl_diaria");
            entity.Property(e => e.VlMultaHora)
                .HasPrecision(15, 2)
                .HasColumnName("vl_multa_hora");
        });

        modelBuilder.Entity<TbQuarto>(entity =>
        {
            entity.HasKey(e => e.IdQuarto).HasName("PRIMARY");

            entity.ToTable("tb_quarto");

            entity.HasIndex(e => e.IdHospedagem, "id_hospedagem");

            entity.Property(e => e.IdQuarto).HasColumnName("id_quarto");
            entity.Property(e => e.BlCafeManha).HasColumnName("bl_cafe_manha");
            entity.Property(e => e.BlDisponivel).HasColumnName("bl_disponivel");
            entity.Property(e => e.BlSuite).HasColumnName("bl_suite");
            entity.Property(e => e.BlVaranda).HasColumnName("bl_varanda");
            entity.Property(e => e.DsQuarto)
                .HasMaxLength(100)
                .HasColumnName("ds_quarto");
            entity.Property(e => e.IdHospedagem).HasColumnName("id_hospedagem");
            entity.Property(e => e.NrQuarto)
                .HasMaxLength(30)
                .HasColumnName("nr_quarto");

            entity.HasOne(d => d.IdHospedagemNavigation).WithMany(p => p.TbQuartos)
                .HasForeignKey(d => d.IdHospedagem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tb_quarto_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
