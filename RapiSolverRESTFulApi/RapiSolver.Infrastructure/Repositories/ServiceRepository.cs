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
    public class ServiceRepository : IServiceRepository
    {
        private ApplicationDbContext context;

        public ServiceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool RegisterService(Servicio entity)
        {
            try
            {
                entity.ServiceCategory = context.categories.Find(entity.ServiceCategoryId);
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public Servicio SearchService(int id)
        {
            var result = new Servicio();
            try
            {
                result = context.servicios.Single(x => x.ServicioId == id);
            }

            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<ServiceDTO> ShowServices()
        {
            var servicios = context.servicios
              .Include(o => o.ServiceCategory)
              .OrderByDescending(o => o.ServiceCategoryId)
              .Take(10)
              .ToList();

            return servicios.Select(o => new ServiceDTO
            {
                ServicioId = o.ServicioId,
                Name = o.Name,
                Description = o.Description,
                Cost = o.Cost,
                ServiceCategoryId = o.ServiceCategoryId,
                CategoryName = o.ServiceCategory.CategoryName

            });
        }

        public IEnumerable<ServiceDTO> ShowServicesByCategory(string name)
        {
            var servicios = context.servicios
                .Include(o => o.ServiceCategory)
                .OrderByDescending(o => o.ServiceCategoryId)
                .Take(10)
                .Where(o => o.ServiceCategory.CategoryName == name)
                .ToList();

            return servicios.Select(o => new ServiceDTO
            {
                ServicioId = o.ServicioId,
                Name = o.Name,
                Description = o.Description,
                Cost = o.Cost,
                ServiceCategoryId = o.ServiceCategoryId,
                CategoryName = o.ServiceCategory.CategoryName

            });
        }

        public IEnumerable<ServiceDTO> ShowServicesBySupplier(int id)
        {
            var detalles = context.serviceDetails
                 .Include(o => o.Servicio)
                 .Include(o => o.Servicio.ServiceCategory)
                 .Where(o => o.SupplierId == id)
                 .ToList();

            return detalles.Select(o => new ServiceDTO
            {
                ServicioId = o.ServicioId,
                Name = o.Servicio.Name,
                Description = o.Servicio.Description,
                Cost = o.Servicio.Cost,
                ServiceCategoryId = o.Servicio.ServiceCategoryId,
                CategoryName = o.Servicio.ServiceCategory.CategoryName

            });
        }

        public IEnumerable<ServiceDTO> ShowServicesByUser(int id)
        {
            var detalles = context.serviceDetails
               .Include(o => o.Servicio)
               .Include(o => o.Supplier)
               .Include(o => o.Supplier.Usuario)
               .Include(o => o.Servicio.ServiceCategory)
               .Where(o => o.Supplier.Usuario.UsuarioId == id)
               .ToList();

            return detalles.Select(o => new ServiceDTO
            {
                ServicioId = o.ServicioId,
                Name = o.Servicio.Name,
                Description = o.Servicio.Description,
                Cost = o.Servicio.Cost,
                ServiceCategoryId = o.Servicio.ServiceCategoryId,
                CategoryName = o.Servicio.ServiceCategory.CategoryName

            });
        }

        public bool UnregisterService(int id)
        {
            var result = new Servicio();
            try
            {
                result = context.servicios.Single(x => x.ServicioId == id);
                context.Remove(result);
                context.SaveChanges();
            }

            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool UpdateService(ServiceDTO serviceDTO)
        {
            try
            {
                Servicio s1 = context.servicios.Find(serviceDTO.ServicioId);
                s1.Cost = serviceDTO.Cost;
                s1.Description = serviceDTO.Description;
                s1.Name = serviceDTO.Name;
                s1.ServiceCategory = context.categories.Where(x => x.CategoryName == serviceDTO.CategoryName).First();
                s1.ServiceCategoryId = s1.ServiceCategory.ServiceCategoryId;

                context.Update(s1);
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
