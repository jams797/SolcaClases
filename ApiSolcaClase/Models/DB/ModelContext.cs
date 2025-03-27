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

        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public virtual DbSet<Products> Products { get; set; }
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

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.Idfact)
                    .HasName("FACTURA_PK");

                entity.ToTable("INVOICE");

                entity.Property(e => e.Idfact)
                    .HasColumnName("IDFACT")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Fecha)
                    .HasColumnName("FECHA")
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.Idinvoicedetail)
                    .HasName("INVOICE_DETAIL_PK");

                entity.ToTable("INVOICE_DETAIL");

                entity.Property(e => e.Idinvoicedetail)
                    .HasColumnName("IDINVOICEDETAIL")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idinvoice)
                    .HasColumnName("IDINVOICE")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idproduct)
                    .HasColumnName("IDPRODUCT")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("NUMBER(10,4)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdinvoicedetailNavigation)
                    .WithOne(p => p.InvoiceDetail)
                    .HasForeignKey<InvoiceDetail>(d => d.Idinvoicedetail)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVOICE_DETAIL_FK2");

                entity.HasOne(d => d.IdproductNavigation)
                    .WithMany(p => p.InvoiceDetail)
                    .HasForeignKey(d => d.Idproduct)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("INVOICE_DETAIL_FK1");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Idproduct)
                    .HasName("PRODUCTS_PK");

                entity.ToTable("PRODUCTS");

                entity.Property(e => e.Idproduct)
                    .HasColumnName("IDPRODUCT")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nameproduct)
                    .IsRequired()
                    .HasColumnName("NAMEPRODUCT")
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("NUMBER(10,4)")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.Qty)
                    .HasColumnName("QTY")
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedNever();
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

                entity.Property(e => e.Balance)
                    .HasColumnName("BALANCE")
                    .HasColumnType("NUMBER(10,4)")
                    .ValueGeneratedNever();

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

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Userssys)
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USERSSYS_FK1");
            });

            modelBuilder.HasSequence("INVOICE_DETAIL_SEQ");

            modelBuilder.HasSequence("INVOICE_SEQ");

            modelBuilder.HasSequence("PRODUCTS_SEQ");

            modelBuilder.HasSequence("ROLUSER_SEQ");

            modelBuilder.HasSequence("USERS_SEQ");

            modelBuilder.HasSequence("USERSSYS_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
