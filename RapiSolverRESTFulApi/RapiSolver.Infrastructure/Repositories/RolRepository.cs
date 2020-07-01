using RapiSolver.Core.Entities;
using RapiSolver.Core.Interfaces;
using RapiSolver.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapiSolver.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private ApplicationDbContext context;

        public RolRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Rol SearchRol(int id)
        {
            var result = new Rol();
            try
            {
                result = context.roles.Single(x => x.RolId == id);
            }

            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Rol> ShowRoles()
        {
            var result = new List<Rol>();
            try
            {
                result = context.roles.ToList();
            }

            catch (System.Exception)
            {

                throw;
            }
            return result;
        }

        public bool UnregisterRol(int id)
        {
            try
            {
                Rol r1 = context.roles.Find(id);
                context.Remove(r1);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public bool RegisterRol(Rol entity)
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

       
    }
}
