using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RapiSolver.Infrastructure.Repositories
{
    public class LocationRepository : ILocationRepository
    {

        private ApplicationDbContext context;

        public LocationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool RegisterLocation(Location entity)
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

        public Location SearchLocation(int id)
        {
            var result = new Location();
            try
            {
                result = context.locations.Single(x => x.LocationId == id);
            }

            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Location> ShowLocations()
        {
            var result = new List<Location>();
            try
            {
                result = context.locations.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }
    }
}
