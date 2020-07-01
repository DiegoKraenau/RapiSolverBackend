using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RapiSolver.Infrastructure.Repositories
{
    public class ServiceCategoryRepository : IServiceCategoryRepository
    {

        private ApplicationDbContext context;

        public ServiceCategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public bool RegisterCategory(ServiceCategory entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public ServiceCategory SearchCategory(int id)
        {
            var result = new ServiceCategory();
            try
            {
                result = context.categories.Single(x => x.ServiceCategoryId == id);
            }

            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<ServiceCategory> ShowCategories()
        {
            var result = new List<ServiceCategory>();
            try
            {
                result = context.categories.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
    }
}
