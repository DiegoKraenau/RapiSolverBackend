using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using RapiSolver.Core.Entities;

namespace RapiSolver.Infrastructure.Data
{
    public class ApplicationDbContext: DbContext
    {
      

        public DbSet<Rol> roles { get; set; }

        public DbSet<Usuario> usuarios { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<ServiceCategory> categories { get; set; }

        public DbSet<Servicio> servicios { get; set; }

        public DbSet<ServiceDetails> serviceDetails { get; set; }

        public DbSet<Location> locations { get; set; }

        public DbSet<Recommendation> recommendations { get; set; }

        public DbSet<Reservation> reservations { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>(b =>
            {
                b.HasKey(e => e.UsuarioId);
                b.Property(e => e.UsuarioId).ValueGeneratedOnAdd();
            });

            //modelBuilder.Entity<Usuario>().HasMany(x=>x.Roles).WithOne(o=>o.Usuario);


            modelBuilder.Entity<Supplier>(b =>
            {
                b.HasKey(e => e.SupplierId);
                b.Property(e => e.SupplierId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Supplier>().HasOne(x => x.Usuario);

            modelBuilder.Entity<Customer>(b =>
            {
                b.HasKey(e => e.CustomerId);
                b.Property(e => e.CustomerId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Customer>().HasOne(x => x.Usuario);

            modelBuilder.Entity<Customer>().HasOne(x => x.Location);

            modelBuilder.Entity<Supplier>().HasOne(x => x.Location);

            modelBuilder.Entity<Location>(b =>
            {
                b.HasKey(e => e.LocationId);
                b.Property(e => e.LocationId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ServiceCategory>(b =>
            {
                b.HasKey(e => e.ServiceCategoryId);
                b.Property(e => e.ServiceCategoryId).ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<ServiceCategory>().HasMany(x => x.Servicios).WithOne(o => o.ServiceCategory);

            modelBuilder.Entity<ServiceDetails>(b =>
            {
                b.HasKey(e => e.ServiceDetailsId);
                b.Property(e => e.ServiceDetailsId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Recommendation>(b =>
            {
                b.HasKey(e => e.RecommendationId);
                b.Property(e => e.RecommendationId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Recommendation>().HasOne(x => x.Supplier);

            modelBuilder.Entity<Recommendation>().HasOne(x => x.Usuario);

            modelBuilder.Entity<Reservation>(b =>
            {
                b.HasKey(e => e.ReservationId);
                b.Property(e => e.ReservationId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Reservation>().HasOne(x => x.Supplier);

            modelBuilder.Entity<Reservation>().HasOne(x => x.Usuario);


        }
    }
}
