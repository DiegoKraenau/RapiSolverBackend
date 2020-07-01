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
    public class UsuarioRepository : IUsuarioRepository
    {

        private ApplicationDbContext context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public UsuarioDTO Login(string email, string password)
        {
            try
            {
                var usuario = context.usuarios.
                                Include(x => x.Rol).
                                Single(x => x.UserName == email && x.UserPassword == password);

                UsuarioDTO usuario1 = new UsuarioDTO();
                usuario1.UsuarioId = usuario.UsuarioId;
                usuario1.UserName = usuario.UserName;
                usuario1.UserPassword = usuario.UserPassword;
                usuario1.RolId = usuario.RolId;

                return usuario1;
            }
            catch (Exception e)
            {
                UsuarioDTO usuario1 = new UsuarioDTO();
                usuario1.UsuarioId = 0;
                return usuario1;
            }

        }

        public bool RegisterUser(Usuario entity)
        {
            try
            {
                entity.Rol = context.roles.Find(entity.RolId);

                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {

                return false;
            }
            return true;
        }

        public Usuario SearchUser(int id)
        {
            var result = new Usuario();
            try
            {
                result = context.usuarios.Find(id);
            }

            catch (System.Exception)
            {
                throw;
            }
            return result;
        }
    

        public IEnumerable<UsuarioDTO> ShowUsers()
        {
            var usuario = context.usuarios
               .Include(o => o.Rol)
               .OrderByDescending(o => o.RolId)
               .ToList();

            return usuario.Select(o => new UsuarioDTO
            {
                UsuarioId = o.UsuarioId,
                UserName = o.UserName,
                UserPassword = o.UserPassword,
                RolId = o.Rol.RolId
            });
        }

        public bool UnregisterUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRole(int id)
        {
            try
            {
                Usuario u1 = context.usuarios.Find(id);
                Rol r1 = context.roles.Find(2);
                u1.Rol = r1;
                u1.RolId = 2;


                context.usuarios.Update(u1);
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
