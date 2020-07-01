using RapiSolver.Core.DTOs;
using RapiSolver.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RapiSolver.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        bool UnregisterUser(int id);

        Usuario SearchUser(int id);

        IEnumerable<UsuarioDTO> ShowUsers();

        UsuarioDTO Login(string email, string password);

        bool RegisterUser(Usuario entity);

        bool UpdateRole(int id);


    }
}
