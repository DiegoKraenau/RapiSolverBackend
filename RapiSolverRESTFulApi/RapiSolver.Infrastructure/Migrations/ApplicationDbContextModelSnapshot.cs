﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RapiSolver.Infrastructure.Data;

namespace RapiSolver.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RapiSolver.Core.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Contraseña")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("CustomerId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.HasKey("LocationId");

                    b.ToTable("locations");
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Recommendation", b =>
                {
                    b.Property<int>("RecommendationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Mark")
                        .HasColumnType("double precision");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("RecommendationId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("recommendations");
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Fecha")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<int>("ServicioId")
                        .HasColumnType("integer");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("ReservationId");

                    b.HasIndex("ServicioId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("reservations");
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Publish")
                        .HasColumnType("boolean");

                    b.Property<string>("RolDescription")
                        .HasColumnType("text");

                    b.HasKey("RolId");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.ServiceCategory", b =>
                {
                    b.Property<int>("ServiceCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("text");

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.HasKey("ServiceCategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.ServiceDetails", b =>
                {
                    b.Property<int>("ServiceDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ServicioId")
                        .HasColumnType("integer");

                    b.Property<int>("SupplierId")
                        .HasColumnType("integer");

                    b.HasKey("ServiceDetailsId");

                    b.HasIndex("ServicioId");

                    b.HasIndex("SupplierId");

                    b.ToTable("serviceDetails");
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Servicio", b =>
                {
                    b.Property<int>("ServicioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Cost")
                        .HasColumnType("double precision");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("ServiceCategoryId")
                        .HasColumnType("integer");

                    b.HasKey("ServicioId");

                    b.HasIndex("ServiceCategoryId");

                    b.ToTable("servicios");
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Contraseña")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<int>("LocationId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("SupplierId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("suppliers");
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("RolId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .HasColumnType("text");

                    b.HasKey("UsuarioId");

                    b.HasIndex("RolId");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Customer", b =>
                {
                    b.HasOne("RapiSolver.Core.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RapiSolver.Core.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Recommendation", b =>
                {
                    b.HasOne("RapiSolver.Core.Entities.Supplier", "Supplier")
                        .WithMany("Recommendations")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RapiSolver.Core.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Reservation", b =>
                {
                    b.HasOne("RapiSolver.Core.Entities.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RapiSolver.Core.Entities.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RapiSolver.Core.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.ServiceDetails", b =>
                {
                    b.HasOne("RapiSolver.Core.Entities.Servicio", "Servicio")
                        .WithMany()
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RapiSolver.Core.Entities.Supplier", "Supplier")
                        .WithMany("ServiciosDetails")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Servicio", b =>
                {
                    b.HasOne("RapiSolver.Core.Entities.ServiceCategory", "ServiceCategory")
                        .WithMany("Servicios")
                        .HasForeignKey("ServiceCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Supplier", b =>
                {
                    b.HasOne("RapiSolver.Core.Entities.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RapiSolver.Core.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RapiSolver.Core.Entities.Usuario", b =>
                {
                    b.HasOne("RapiSolver.Core.Entities.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
