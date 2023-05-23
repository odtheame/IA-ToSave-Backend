using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IA_ToSave.Models;

public partial class IaToSaveContext : DbContext
{
    public IaToSaveContext()
    {
    }

    public IaToSaveContext(DbContextOptions<IaToSaveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<Incidencia> Incidencias { get; set; }

    public virtual DbSet<Informe> Informes { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Ubicacione> Ubicaciones { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PCGAMERNOVAXD\\SQLEXPRESS; Database=IA-ToSave; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCli).HasName("PK__Clientes__398F67058A848395");

            entity.HasIndex(e => e.Nit, "UQ__Clientes__DF97D0E446A7114F").IsUnique();

            entity.Property(e => e.IdCli).HasColumnName("idCli");
            entity.Property(e => e.Dir)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("dir");
            entity.Property(e => e.IdPrsn).HasColumnName("idPrsn");
            entity.Property(e => e.Nit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Nom)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nom");

            entity.HasOne(d => d.IdPrsnNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdPrsn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Clientes__idPrsn__6477ECF3");
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasKey(e => e.IdDoc).HasName("PK__Document__3E4114466F8552CA");

            entity.Property(e => e.IdDoc).HasColumnName("idDoc");
            entity.Property(e => e.Bucket)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("bucket");
            entity.Property(e => e.IdBucket)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("idBucket");
        });

        modelBuilder.Entity<Incidencia>(entity =>
        {
            entity.HasKey(e => e.IdIcdc).HasName("PK__Incidenc__B2F56B4B76AAA756");

            entity.Property(e => e.IdIcdc).HasColumnName("idIcdc");
            entity.Property(e => e.Anmla)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("anmla");
            entity.Property(e => e.Apbc).HasColumnName("apbc");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdUbi).HasColumnName("idUbi");
            entity.Property(e => e.Sjts)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sjts");

            entity.HasOne(d => d.IdUbiNavigation).WithMany(p => p.Incidencia)
                .HasForeignKey(d => d.IdUbi)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Incidenci__idUbi__6A30C649");
        });

        modelBuilder.Entity<Informe>(entity =>
        {
            entity.HasKey(e => e.IdInf).HasName("PK__Informes__3C3EB37A238A6144");

            entity.Property(e => e.IdInf).HasColumnName("idInf");
            entity.Property(e => e.Descr)
                .HasColumnType("text")
                .HasColumnName("descr");
            entity.Property(e => e.IdDoc).HasColumnName("idDoc");
            entity.Property(e => e.IdIcdc).HasColumnName("idIcdc");
            entity.Property(e => e.NInf)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nInf");

            entity.HasOne(d => d.IdDocNavigation).WithMany(p => p.Informes)
                .HasForeignKey(d => d.IdDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Informes__idDoc__6FE99F9F");

            entity.HasOne(d => d.IdIcdcNavigation).WithMany(p => p.Informes)
                .HasForeignKey(d => d.IdIcdc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Informes__idIcdc__6EF57B66");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPrsn).HasName("PK__Personas__B41BD16FBE9C129F");

            entity.HasIndex(e => e.NDcmt, "UQ__Personas__2B22F3D837DB70D5").IsUnique();

            entity.Property(e => e.IdPrsn).HasColumnName("idPrsn");
            entity.Property(e => e.Correo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.FeIngr)
                .HasColumnType("date")
                .HasColumnName("feIngr");
            entity.Property(e => e.FeNaci)
                .HasColumnType("date")
                .HasColumnName("feNaci");
            entity.Property(e => e.NDcmt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("nDcmt");
            entity.Property(e => e.PrApe)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("prApe");
            entity.Property(e => e.PrNom)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("prNom");
            entity.Property(e => e.SdApe)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("sdApe");
            entity.Property(e => e.SdNom)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("sdNom");
            entity.Property(e => e.Telef)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telef");
        });

        modelBuilder.Entity<Ubicacione>(entity =>
        {
            entity.HasKey(e => e.IdUbi).HasName("PK__Ubicacio__03D7968678E6CF7D");

            entity.Property(e => e.IdUbi).HasColumnName("idUbi");
            entity.Property(e => e.Cdad)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("cdad");
            entity.Property(e => e.Dpto)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("dpto");
            entity.Property(e => e.IdUsr).HasColumnName("idUsr");
            entity.Property(e => e.Lcld)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("lcld");
            entity.Property(e => e.NCdt)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nCdt");

            entity.HasOne(d => d.IdUsrNavigation).WithMany(p => p.Ubicaciones)
                .HasForeignKey(d => d.IdUsr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ubicacion__idUsr__6754599E");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsr).HasName("PK__Usuarios__03D71CF87EF2F1A7");

            entity.Property(e => e.IdUsr).HasColumnName("idUsr");
            entity.Property(e => e.IdPrsn).HasColumnName("idPrsn");
            entity.Property(e => e.Pass)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Usr)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("usr");

            entity.HasOne(d => d.IdPrsnNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPrsn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__idPrsn__60A75C0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
