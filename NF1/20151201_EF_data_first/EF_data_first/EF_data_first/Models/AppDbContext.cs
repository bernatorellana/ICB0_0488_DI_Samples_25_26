using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF_data_first.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Comandum> Comanda { get; set; }

    public virtual DbSet<Dept> Depts { get; set; }

    public virtual DbSet<Detall> Detalls { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Emp> Emps { get; set; }

    public virtual DbSet<Id> Ids { get; set; }

    public virtual DbSet<Producte> Productes { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=empresa;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientCod).HasName("PRIMARY");

            entity.ToTable("client");

            entity.HasIndex(e => e.ReprCod, "REPR_COD");

            entity.Property(e => e.ClientCod)
                .HasPrecision(6)
                .HasColumnName("CLIENT_COD");
            entity.Property(e => e.Area)
                .HasPrecision(3)
                .HasColumnName("AREA");
            entity.Property(e => e.Ciutat)
                .HasMaxLength(30)
                .HasColumnName("CIUTAT");
            entity.Property(e => e.CodiPostal)
                .HasMaxLength(9)
                .HasColumnName("CODI_POSTAL");
            entity.Property(e => e.Direccio)
                .HasMaxLength(40)
                .HasColumnName("DIRECCIO");
            entity.Property(e => e.Estat)
                .HasMaxLength(2)
                .HasColumnName("ESTAT");
            entity.Property(e => e.LimitCredit)
                .HasPrecision(9, 2)
                .HasColumnName("LIMIT_CREDIT");
            entity.Property(e => e.Nom)
                .HasMaxLength(45)
                .HasColumnName("NOM");
            entity.Property(e => e.Observacions)
                .HasMaxLength(200)
                .HasColumnName("OBSERVACIONS");
            entity.Property(e => e.ReprCod)
                .HasColumnType("int(4)")
                .HasColumnName("REPR_COD");
            entity.Property(e => e.Telefon)
                .HasMaxLength(9)
                .HasColumnName("TELEFON");

            entity.HasOne(d => d.ReprCodNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ReprCod)
                .HasConstraintName("client_ibfk_1");
        });

        modelBuilder.Entity<Comandum>(entity =>
        {
            entity.HasKey(e => e.ComNum).HasName("PRIMARY");

            entity.ToTable("comanda");

            entity.HasIndex(e => e.ClientCod, "CLIENT_COD");

            entity.Property(e => e.ComNum)
                .HasPrecision(4)
                .HasColumnName("COM_NUM");
            entity.Property(e => e.ClientCod)
                .HasPrecision(6)
                .HasColumnName("CLIENT_COD");
            entity.Property(e => e.ComData)
                .HasColumnType("datetime")
                .HasColumnName("COM_DATA");
            entity.Property(e => e.ComTipus)
                .HasMaxLength(1)
                .HasColumnName("COM_TIPUS");
            entity.Property(e => e.DataTramesa)
                .HasColumnType("datetime")
                .HasColumnName("DATA_TRAMESA");
            entity.Property(e => e.Total)
                .HasPrecision(8, 2)
                .HasColumnName("TOTAL");

            entity.HasOne(d => d.ClientCodNavigation).WithMany(p => p.Comanda)
                .HasForeignKey(d => d.ClientCod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comanda_ibfk_1");
        });

        modelBuilder.Entity<Dept>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PRIMARY");

            entity.ToTable("dept");

            entity.Property(e => e.DeptNo)
                .HasPrecision(2)
                .HasColumnName("DEPT_NO");
            entity.Property(e => e.Dnom)
                .HasMaxLength(14)
                .HasColumnName("DNOM");
            entity.Property(e => e.Loc)
                .HasMaxLength(14)
                .HasColumnName("LOC");
        });

        modelBuilder.Entity<Detall>(entity =>
        {
            entity.HasKey(e => new { e.ComNum, e.DetallNum })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("detall");

            entity.HasIndex(e => e.ProdNum, "PROD_NUM");

            entity.Property(e => e.ComNum)
                .HasPrecision(4)
                .HasColumnName("COM_NUM");
            entity.Property(e => e.DetallNum)
                .HasPrecision(4)
                .HasColumnName("DETALL_NUM");
            entity.Property(e => e.Import)
                .HasPrecision(8, 2)
                .HasColumnName("IMPORT");
            entity.Property(e => e.PreuVenda)
                .HasPrecision(8, 2)
                .HasColumnName("PREU_VENDA");
            entity.Property(e => e.ProdNum)
                .HasPrecision(6)
                .HasColumnName("PROD_NUM");
            entity.Property(e => e.Quantitat)
                .HasPrecision(8)
                .HasColumnName("QUANTITAT");

            entity.HasOne(d => d.ComNumNavigation).WithMany(p => p.Detalls)
                .HasForeignKey(d => d.ComNum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detall_ibfk_1");

            entity.HasOne(d => d.ProdNumNavigation).WithMany(p => p.Detalls)
                .HasForeignKey(d => d.ProdNum)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("detall_ibfk_2");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Emp>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PRIMARY");

            entity.ToTable("emp");

            entity.HasIndex(e => e.Cap, "CAP");

            entity.HasIndex(e => e.DeptNo, "DEPT_NO");

            entity.Property(e => e.EmpNo)
                .HasColumnType("int(4)")
                .HasColumnName("EMP_NO");
            entity.Property(e => e.Cap)
                .HasColumnType("int(4)")
                .HasColumnName("CAP");
            entity.Property(e => e.Cognom)
                .HasMaxLength(10)
                .HasColumnName("COGNOM");
            entity.Property(e => e.Comissio)
                .HasPrecision(10)
                .HasColumnName("COMISSIO");
            entity.Property(e => e.DataAlta)
                .HasColumnType("datetime")
                .HasColumnName("DATA_ALTA");
            entity.Property(e => e.DeptNo)
                .HasPrecision(2)
                .HasColumnName("DEPT_NO");
            entity.Property(e => e.Ofici)
                .HasMaxLength(10)
                .HasColumnName("OFICI");
            entity.Property(e => e.Salari)
                .HasPrecision(10)
                .HasColumnName("SALARI");

            entity.HasOne(d => d.CapNavigation).WithMany(p => p.InverseCapNavigation)
                .HasForeignKey(d => d.Cap)
                .HasConstraintName("emp_ibfk_1");

            entity.HasOne(d => d.DeptNoNavigation).WithMany(p => p.Emps)
                .HasForeignKey(d => d.DeptNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("emp_ibfk_2");
        });

        modelBuilder.Entity<Id>(entity =>
        {
            entity.HasKey(e => e.TableName).HasName("PRIMARY");

            entity.ToTable("ids");

            entity.Property(e => e.TableName)
                .HasMaxLength(30)
                .HasColumnName("TABLE_NAME");
            entity.Property(e => e.LastId)
                .HasPrecision(10)
                .HasColumnName("LAST_ID");
        });

        modelBuilder.Entity<Producte>(entity =>
        {
            entity.HasKey(e => e.ProdNum).HasName("PRIMARY");

            entity.ToTable("producte");

            entity.Property(e => e.ProdNum)
                .HasPrecision(6)
                .HasColumnName("PROD_NUM");
            entity.Property(e => e.Descripcio)
                .HasMaxLength(30)
                .HasColumnName("DESCRIPCIO");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Course).HasColumnName("course");
            entity.Property(e => e.Stname).HasColumnName("stname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
