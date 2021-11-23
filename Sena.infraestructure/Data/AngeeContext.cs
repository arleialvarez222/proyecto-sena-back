using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Sena.core.Models;

namespace Sena.infraestructure.Data
{
    public class AngeeContext : IdentityDbContext<Users>
    {

        public AngeeContext(DbContextOptions<AngeeContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Reserva> Reserva { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.Property(e => e.IdCliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCliente");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("direccion");

                entity.Property(e => e.Documento)
                    .HasColumnType("int(20)")
                    .HasColumnName("documento");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombres");

                entity.Property(e => e.Telefono)
                    .HasColumnType("int(10)")
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdEmpleado)
                    .HasName("PRIMARY");

                entity.ToTable("empleado");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEmpleado");

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("apellidos");

                entity.Property(e => e.ComisionEmpleado)
                    .HasColumnName("Comision_Empleado")
                    .HasDefaultValueSql("NULL");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("correo");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("direccion");

                entity.Property(e => e.Documento)
                    .HasColumnType("int(20)")
                    .HasColumnName("documento");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombres");

                entity.Property(e => e.SalarioEmpleado).HasColumnName("Salario_Empleado");

                entity.Property(e => e.SegSocEmpleado)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Seg_Soc_Empleado");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PRIMARY");

                entity.ToTable("inventario");

                entity.HasIndex(e => e.IdProducto, "FK_Inventario_Producto_id_idx");

                entity.Property(e => e.IdInventario)
                    .HasColumnType("int(11)")
                    .HasColumnName("idInventario");

                entity.Property(e => e.CantDisponibleProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("CantDisponible_Producto");

                entity.Property(e => e.CantMinimaProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("CantMinima_Producto");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("idProducto");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Inventarios)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK_Inventario_Producto_id");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PRIMARY");

                entity.ToTable("pedido");

                entity.HasIndex(e => e.IdCliente, "FK_Pedido_Cliente_id_idx");

                entity.HasIndex(e => e.IdEmpleado, "FK_Pedido_Empleado_id_idx");

                entity.Property(e => e.IdPedido)
                    .HasColumnType("int(11)")
                    .HasColumnName("idPedido");

                entity.Property(e => e.EstadoPedido)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Estado_Pedido");

                entity.Property(e => e.FechaVentaPedido)
                    .HasColumnType("date")
                    .HasColumnName("FechaVenta_Pedido");

                entity.Property(e => e.IdCliente)
                    .HasColumnType("int(11)")
                    .HasColumnName("idCliente");

                entity.Property(e => e.IdEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEmpleado");

                entity.Property(e => e.MontoFinalPedido).HasColumnName("MontoFinal_Pedido");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK_Pedido_Cliente_id");

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK_Pedido_Empleado_id");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PRIMARY");

                entity.ToTable("producto");

                entity.Property(e => e.IdProducto)
                    .HasColumnType("int(11)")
                    .HasColumnName("idProducto");

                entity.Property(e => e.DescribProducto)
                    .HasMaxLength(200)
                    .HasColumnName("Describ_Producto")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Nombre_Producto");

            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProveedor)
                    .HasName("PRIMARY");

                entity.ToTable("proveedor");

                entity.Property(e => e.IdProveedor)
                    .HasColumnType("int(11)")
                    .HasColumnName("idProveedor");

                entity.Property(e => e.NombreProveedor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Nombre_Proveedor");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Telefono");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Direccion");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("Email");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva)
                    .HasName("PRIMARY");

                entity.ToTable("reserva");

                entity.HasIndex(e => e.IdEmpleado, "FK_Reserva_Empleado_id_idx");

                entity.Property(e => e.IdReserva)
                    .HasColumnType("int(11)")
                    .HasColumnName("idReserva");

                entity.Property(e => e.Domicilio)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.IdEmpleado)
                    .HasColumnType("int(11)")
                    .HasColumnName("idEmpleado");

                entity.Property(e => e.Redamar)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.HasOne(d => d.Empleado)
                    .WithMany(p => p.Reservas)
                    .HasForeignKey(d => d.IdEmpleado)
                    .HasConstraintName("FK_Reserva_Empleado_id");
            });

            base.OnModelCreating(modelBuilder);
        }

        
    }
}
