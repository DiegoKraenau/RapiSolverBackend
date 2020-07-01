using RapiSolver.Core.Entities;

using System.Collections.Generic;


namespace RapiSolver.Core.Interfaces
{
    public interface IRolRepository
    {
        bool UnregisterRol(int id);

        Rol SearchRol(int id);

        IEnumerable<Rol> ShowRoles();

        bool RegisterRol(Rol entity);

    }
}
