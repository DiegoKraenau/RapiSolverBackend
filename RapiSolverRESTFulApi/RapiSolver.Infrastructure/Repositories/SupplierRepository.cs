using Microsoft.EntityFrameworkCore;
using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RapiSolver.Infrastructure.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {


        private ApplicationDbContext context;

        public SupplierRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public bool RegisterSupplier(Supplier entity)
        {
            try
            {
                Usuario u1 = new Usuario();
                u1.UserName = entity.Email;
                u1.UserPassword = entity.Contraseña;
                u1.RolId = 2;
                u1.Rol = context.roles.Find(u1.RolId);

                context.Add(u1);
                context.SaveChanges();

                entity.UsuarioId = context.usuarios.Single(x => x.UserName == entity.Email).UsuarioId;

                Location l1 = new Location();
                l1.Country = entity.Country;
                l1.City = entity.City;
                l1.State = entity.State;
                l1.Address = entity.Address;

                context.Add(l1);
                context.SaveChanges();

                entity.Location = l1;
                entity.LocationId = 1;

                entity.Usuario = context.usuarios.Find(entity.UsuarioId);

                context.Add(entity);
                context.SaveChanges();
                //  entity.ServiciosDetails=context.serviceDetails.Where(y=>y.SupplierId==entity.SupplierId).ToList();


            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public Supplier SearchOriginalSupplierByUserId(int id)
        {
            var result = new Supplier();
            try
            {
                result = context.suppliers.Where(x => x.UsuarioId == id).First();
            }

            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public Supplier SearchSupplier(int id)
        {
            var result = new Supplier();
            try
            {
                result = context.suppliers.Find(id);
            }

            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<SupplierDTO> SearchSupplierByUserId(int id)
        {
            var suppliers = context.suppliers
               .Include(o => o.Usuario)
               .Include(o => o.Location)
               .OrderByDescending(o => o.SupplierId)
               .Where(o => o.UsuarioId == id)
               .ToList();

            return suppliers.Select(o => new SupplierDTO
            {
                SupplierId = o.SupplierId,
                Name = o.Name,
                LastName = o.LastName,
                Email = o.Email,
                Phone = o.Phone,
                Age = o.Age,
                Gender = o.Gender,
                UsuarioId = o.UsuarioId,
                LocationId = o.LocationId,
                UserName = o.Usuario.UserName,
                Country = o.Location.Country,
                //    ServiciosDetails=context.serviceDetails.ToList() No se puede pasar listas al json
            });
        }

        public IEnumerable<SupplierDTO> ShowSuppliers()
        {
            var suppliers = context.suppliers
               .Include(o => o.Usuario)
               .Include(o => o.Location)
               .OrderByDescending(o => o.SupplierId)
               .Take(10)
               .ToList();

            return suppliers.Select(o => new SupplierDTO
            {
                SupplierId = o.SupplierId,
                Name = o.Name,
                LastName = o.LastName,
                Email = o.Email,
                Phone = o.Phone,
                Age = o.Age,
                Gender = o.Gender,
                UsuarioId = o.UsuarioId,
                LocationId = o.LocationId,
                UserName = o.Usuario.UserName,
                Country = o.Location.Country,
                //    ServiciosDetails=context.serviceDetails.ToList() No se puede pasar listas al json
            });
        }

        public IEnumerable<SupplierDTO> ShowSuppliersBySurname(string surname)
        {
            var suppliers = context.suppliers
                .Include(o => o.Usuario)
                .Include(o => o.Location)
                .OrderByDescending(o => o.SupplierId)
                .Where(o => o.LastName == surname)
                .ToList();

            return suppliers.Select(o => new SupplierDTO
            {
                SupplierId = o.SupplierId,
                Name = o.Name,
                LastName = o.LastName,
                Email = o.Email,
                Phone = o.Phone,
                Age = o.Age,
                Gender = o.Gender,
                UsuarioId = o.UsuarioId,
                LocationId = o.LocationId,
                UserName = o.Usuario.UserName,
                Country = o.Location.Country,
                //    ServiciosDetails=context.serviceDetails.ToList() No se puede pasar listas al json
            });
        }

        public bool UpdateSupplier(Supplier entity)
        {
            try
            {
                Supplier c1 = context.suppliers.Find(entity.SupplierId);
                Usuario u1 = context.usuarios.Find(c1.UsuarioId);
                Console.WriteLine(u1.UsuarioId);
                u1.UserName = entity.Email;
                u1.UserPassword = entity.Contraseña;
                u1.RolId = 2;
                u1.Rol = context.roles.Find(u1.RolId);
                context.Update(u1);
                context.SaveChanges();


                Location l1 = context.locations.Find(c1.LocationId);
                l1.Country = entity.Country;
                l1.City = entity.City;
                l1.State = entity.State;
                l1.Address = entity.Address;

                context.Update(l1);
                context.SaveChanges();

                c1.Gender = entity.Gender;
                c1.LastName = entity.LastName;
                c1.Name = entity.Name;
                c1.Phone = entity.Phone;
                c1.Age = entity.Age;
                c1.Email = entity.Email;
                c1.Contraseña = entity.Contraseña;
                c1.City = entity.City;
                c1.Country = entity.Country;
                c1.State = entity.State;
                c1.Address = entity.Address;



                context.Update(c1);
                context.SaveChanges();




            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }
    
    }
}
