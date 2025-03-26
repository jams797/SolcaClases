using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ApiSolcaClase.Models.DB
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Roluser> Roluser { get; set; }
        public virtual DbSet<Userssys> Userssys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseOracle("User Id=CURSO_SOLCA;Password=viamatica2020;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=Curso-BG4)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "CURSO_SOLCA");

            modelBuilder.Entity<Empleados>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("SYS_C006998");

                entity.ToTable("EMPLEADOS");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnName("ID_EMPLEADO")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Apellido)
                    .HasColumnName("APELLIDO")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Departamento)
                    .HasColumnName("DEPARTAMENTO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("FECHA_INGRESO")
                    .HasColumnType("DATE")
                    .HasDefaultValueSql(@"SYSDATE    -- Fecha de ingreso con valor por defecto (fecha actual)
");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnName("FECHA_NACIMIENTO")
                    .HasColumnType("DATE");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Salario)
                    .HasColumnName("SALARIO")
                    .HasColumnType("NUMBER(10,2)");
            });

            modelBuilder.Entity<Roluser>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("ROLUSER_PK");

                entity.ToTable("ROLUSER");

                entity.HasIndex(e => e.Namerol)
                    .HasName("ROLUSER_NAME_IDX")
                    .IsUnique();

                entity.Property(e => e.Idrol)
                    .HasColumnName("IDROL")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Namerol)
                    .IsRequired()
                    .HasColumnName("NAMEROL")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Userssys>(entity =>
            {
                entity.HasKey(e => e.Iduser)
                    .HasName("USERS_PK");

                entity.ToTable("USERSSYS");

                entity.HasIndex(e => e.Email)
                    .HasName("USERS_EMAIL")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("USERS_USER")
                    .IsUnique();

                entity.Property(e => e.Iduser)
                    .HasColumnName("IDUSER")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idrol)
                    .HasColumnName("IDROL")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nameperson)
                    .IsRequired()
                    .HasColumnName("NAMEPERSON")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("PASS")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("USERNAME")
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.HasSequence("ROLUSER_SEQ");

            modelBuilder.HasSequence("USERS_SEQ");

            modelBuilder.HasSequence("USERSSYS_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
