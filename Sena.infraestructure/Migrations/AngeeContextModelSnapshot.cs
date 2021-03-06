// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sena.infraestructure.Data;

namespace Sena.infraestructure.Migrations
{
    [DbContext(typeof(AngeeContext))]
    partial class AngeeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Sena.core.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("idCliente");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("apellidos");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("correo");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("direccion");

                    b.Property<int>("Documento")
                        .HasColumnType("int(20)")
                        .HasColumnName("documento");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombres");

                    b.Property<int>("Telefono")
                        .HasColumnType("int(10)")
                        .HasColumnName("telefono");

                    b.HasKey("IdCliente")
                        .HasName("PRIMARY");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Sena.core.Models.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("idEmpleado");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("apellidos");

                    b.Property<decimal?>("ComisionEmpleado")
                        .HasColumnType("decimal(18, 2)")
                        .HasColumnName("Comision_Empleado")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("correo");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("direccion");

                    b.Property<int>("Documento")
                        .HasColumnType("int(20)")
                        .HasColumnName("documento");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("nombres");

                    b.Property<double>("SalarioEmpleado")
                        .HasColumnType("double")
                        .HasColumnName("Salario_Empleado");

                    b.Property<string>("SegSocEmpleado")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Seg_Soc_Empleado");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("telefono");

                    b.HasKey("IdEmpleado")
                        .HasName("PRIMARY");

                    b.ToTable("empleado");
                });

            modelBuilder.Entity("Sena.core.Models.Inventario", b =>
                {
                    b.Property<int>("IdInventario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("idInventario");

                    b.Property<int>("CantDisponibleProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("CantDisponible_Producto");

                    b.Property<int>("CantMinimaProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("CantMinima_Producto");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int(11)")
                        .HasColumnName("idProducto");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("IdInventario")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdProducto" }, "FK_Inventario_Producto_id_idx");

                    b.ToTable("inventario");
                });

            modelBuilder.Entity("Sena.core.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("idPedido");

                    b.Property<string>("EstadoPedido")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Estado_Pedido");

                    b.Property<DateTime>("FechaVentaPedido")
                        .HasColumnType("date")
                        .HasColumnName("FechaVenta_Pedido");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int(11)")
                        .HasColumnName("idCliente");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int(11)")
                        .HasColumnName("idEmpleado");

                    b.Property<float>("MontoFinalPedido")
                        .HasColumnType("float")
                        .HasColumnName("MontoFinal_Pedido");

                    b.HasKey("IdPedido")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCliente" }, "FK_Pedido_Cliente_id_idx");

                    b.HasIndex(new[] { "IdEmpleado" }, "FK_Pedido_Empleado_id_idx");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("Sena.core.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("idProducto");

                    b.Property<string>("DescribProducto")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Describ_Producto")
                        .HasDefaultValueSql("'NULL'");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Nombre_Producto");

                    b.HasKey("IdProducto")
                        .HasName("PRIMARY");

                    b.ToTable("producto");
                });

            modelBuilder.Entity("Sena.core.Models.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("idProveedor");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Direccion");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Email");

                    b.Property<string>("NombreProveedor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nombre_Proveedor");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Telefono");

                    b.HasKey("IdProveedor")
                        .HasName("PRIMARY");

                    b.ToTable("proveedor");
                });

            modelBuilder.Entity("Sena.core.Models.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("idReserva");

                    b.Property<string>("Domicilio")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int(11)")
                        .HasColumnName("idEmpleado");

                    b.Property<string>("Redamar")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("IdReserva")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdEmpleado" }, "FK_Reserva_Empleado_id_idx");

                    b.ToTable("reserva");
                });

            modelBuilder.Entity("Sena.core.Models.Users", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sena.core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sena.core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sena.core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sena.core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sena.core.Models.Inventario", b =>
                {
                    b.HasOne("Sena.core.Models.Producto", "Producto")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("FK_Inventario_Producto_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Sena.core.Models.Pedido", b =>
                {
                    b.HasOne("Sena.core.Models.Cliente", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK_Pedido_Cliente_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sena.core.Models.Empleado", "Empleado")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdEmpleado")
                        .HasConstraintName("FK_Pedido_Empleado_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Sena.core.Models.Reserva", b =>
                {
                    b.HasOne("Sena.core.Models.Empleado", "Empleado")
                        .WithMany("Reservas")
                        .HasForeignKey("IdEmpleado")
                        .HasConstraintName("FK_Reserva_Empleado_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empleado");
                });

            modelBuilder.Entity("Sena.core.Models.Cliente", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Sena.core.Models.Empleado", b =>
                {
                    b.Navigation("Pedidos");

                    b.Navigation("Reservas");
                });

            modelBuilder.Entity("Sena.core.Models.Producto", b =>
                {
                    b.Navigation("Inventarios");
                });
#pragma warning restore 612, 618
        }
    }
}
