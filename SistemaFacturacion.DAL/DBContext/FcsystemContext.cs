using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacion.Model;

namespace SistemaFacturacion.DAL.DBContext;

public partial class FcsystemContext : DbContext
{
    public FcsystemContext()
    {
    }

    public FcsystemContext(DbContextOptions<FcsystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Dfactura> Dfacturas { get; set; }

    public virtual DbSet<Hfactura> Hfacturas { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<NumeroDocumento> NumeroDocumentos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB; DataBase=FCSYSTEM; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK_Cliente");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.Idcliente).HasColumnName("IDcliente");
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.Correo).HasMaxLength(80);
            entity.Property(e => e.Direccion).HasMaxLength(80);
            entity.Property(e => e.Ididentificacion)
                .HasMaxLength(25)
                .HasColumnName("IDidentificacion");
            entity.Property(e => e.Imagen).HasColumnType("image");
            entity.Property(e => e.Monto).HasColumnName("MONTO");
            entity.Property(e => e.Nombre).HasMaxLength(80);
            entity.Property(e => e.Pais).HasMaxLength(50);
            entity.Property(e => e.RutaImagen).HasColumnType("text");
            entity.Property(e => e.Sector).HasMaxLength(50);
            entity.Property(e => e.Telefono01).HasMaxLength(20);
            entity.Property(e => e.Telefono02).HasMaxLength(20);
        });

        modelBuilder.Entity<Dfactura>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DFACTURA");

            entity.Property(e => e.Articulo)
                .HasMaxLength(10)
                .HasColumnName("ARTICULO");
            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.Cliente)
                .HasMaxLength(10)
                .HasColumnName("CLIENTE");
            entity.Property(e => e.Factura)
                .HasMaxLength(10)
                .HasColumnName("FACTURA");
            entity.Property(e => e.Fecha)
                .HasMaxLength(8)
                .HasColumnName("FECHA");
            entity.Property(e => e.Impuesto).HasColumnName("IMPUESTO");
            entity.Property(e => e.Montoporlinea).HasColumnName("MONTOPORLINEA");
            entity.Property(e => e.Preciodeventa).HasColumnName("PRECIODEVENTA");
            entity.Property(e => e.Secuencia)
                .ValueGeneratedOnAdd()
                .HasColumnName("SECUENCIA");
        });

        modelBuilder.Entity<Hfactura>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("HFACTURA");

            entity.Property(e => e.Cliente)
                .HasMaxLength(10)
                .HasColumnName("CLIENTE");
            entity.Property(e => e.Factura)
                .HasMaxLength(10)
                .HasColumnName("FACTURA");
            entity.Property(e => e.Fecha)
                .HasMaxLength(8)
                .HasColumnName("FECHA");
            entity.Property(e => e.Impuesto).HasColumnName("IMPUESTO");
            entity.Property(e => e.Montofacturado).HasColumnName("MONTOFACTURADO");
            entity.Property(e => e.Subtotal).HasColumnName("SUBTOTAL");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF48342D3AA95");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icono)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icono");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenuRol).HasName("PK__MenuRol__9D6D61A491FB8154");

            entity.ToTable("MenuRol");

            entity.Property(e => e.IdMenuRol).HasColumnName("idMenuRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MenuRol__idMenu__46E78A0C");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MenuRol__idRol__47DBAE45");
        });

        modelBuilder.Entity<NumeroDocumento>(entity =>
        {
            entity.HasKey(e => e.IdNumeroDocumento).HasName("PK__NumeroDo__471E421A795BD116");

            entity.ToTable("NumeroDocumento");

            entity.Property(e => e.IdNumeroDocumento).HasColumnName("idNumeroDocumento");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.UltimoNumero).HasColumnName("ultimo_Numero");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PRODUCTOS");

            entity.Property(e => e.BarCode).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(80);
            entity.Property(e => e.Imagen).HasColumnType("image");
            entity.Property(e => e.Item).HasMaxLength(10);
            entity.Property(e => e.Ruta).HasColumnType("text");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F7615A33C9B");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6A7C67B7D");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.EsActivo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("esActivo");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaRegistro");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreCompleto");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__idRol__4AB81AF0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
