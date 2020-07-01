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
    public class RecommendationRepository : IRecommendationRepository
    {

        private ApplicationDbContext context;

        public RecommendationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool RegisterRecommendation(Recommendation entity)
        {
            try
            {
                Usuario c1 = new Usuario();
                c1 = context.usuarios.Find(entity.UsuarioId);
                Supplier s1 = new Supplier();
                s1 = context.suppliers.Find(entity.SupplierId);

                entity.Supplier = s1;
                entity.Usuario = c1;
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public Recommendation SearchRecommendation(int id)
        {
            var result = new Recommendation();
            try
            {
                result = context.recommendations.Single(x => x.RecommendationId == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Recommendation> ShowRecommendations()
        {
            var result = new List<Recommendation>();
            try
            {
                result = context.recommendations.ToList();

            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<RecommendationDTO> ShowRecommendationsBySupplier(int id)
        {
            var recommendations = context.recommendations
               .Include(o => o.Supplier)
               .Include(o => o.Usuario)
               .OrderByDescending(o => o.RecommendationId)
               .Where(o => o.SupplierId == id)
               .ToList();


            return recommendations.Select(o => new RecommendationDTO
            {
                RecommendationId = o.RecommendationId,
                Note = o.Note,
                SupplierId = o.SupplierId,
                NameSupllier = o.Supplier.Name,
                LastNameSupllier = o.Supplier.LastName,
                EmailSupllier = o.Supplier.Email,
                UsuarioId = o.UsuarioId,
                UserName = o.Usuario.UserName,
                Mark = o.Mark
            });
        }
    }
}
